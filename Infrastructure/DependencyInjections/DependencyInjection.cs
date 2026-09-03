using EasyReach_Application.CourierService;
using EasyReach_Application.Emails;
using EasyReach_Application.Files;
using EasyReach_Application.Interfaces;
using EasyReach_Application.Interfaces.CurrentUsers;
using EasyReach_Application.Interfaces.JWT;
using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Application.Interfaces.Repositories.HashPasswords;
using EasyReach_Application.Interfaces.Repositories.LandingPages;
using EasyReach_Application.Interfaces.Repositories.Promotions;
using EasyReach_Application.Interfaces.UnitOfWorks;
using EasyReach_Application.IRedis;
using EasyReach_Application.ISslCommerzServices;
using EasyReach_Application.SSLWireless;
using EasyReach_Infrastructure.CourierServices;
using EasyReach_Infrastructure.Emails;
using EasyReach_Infrastructure.Emails.BackgroundWorkers;
using EasyReach_Infrastructure.Emails.SMTP;
using EasyReach_Infrastructure.Files;
using EasyReach_Infrastructure.Persistence;
using EasyReach_Infrastructure.Persistence.Seeders;
using EasyReach_Infrastructure.Redis;
using EasyReach_Infrastructure.Repositories;
using EasyReach_Infrastructure.Repositories.CurrentUsers;
using EasyReach_Infrastructure.Repositories.HashPasswords;
using EasyReach_Infrastructure.Repositories.JWT;
using EasyReach_Infrastructure.Repositories.LandingPages;
using EasyReach_Infrastructure.Repositories.UnitOfWorks;
using EasyReach_Infrastructure.SslCommerzServices;
using EasyReach_Infrastructure.SSLWirelessSMS;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using System.Reflection;
using System.Text;

namespace EasyReach_Infrastructure.DependencyInjections
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // =========================================================
            // 🔐 0. JWT AUTHENTICATION & AUTHORIZATION SETTINGS
            // =========================================================
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["Secret"] ?? "EasyReachSuperSecretKey1234567890!@#$";

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"] ?? "EasyReach",
                    ValidAudience = jwtSettings["Audience"] ?? "EasyReachUsers",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddAuthorization();

            // 🚀 Dynamic JWT Token Generator Service Registration
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

            // File handler Registration 
            services.AddScoped<IFileStorageService, LocalFileStorageService>();

            // Current User Service Registration
            services.AddHttpContextAccessor();
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            // =========================================================
            // 🗄️ 1. DATABASE CONTEXT SETTINGS
            // =========================================================
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            // =========================================================
            // 🔴 REDIS CACHE SETTINGS
            // =========================================================
            services.AddSingleton<IConnectionMultiplexer>(sp =>
                ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis") ?? "localhost:6379"));

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString("Redis") ?? "localhost:6379";
                options.InstanceName = "EasyReach_";
            });

            // গ. Custom Redis Services Registration (Scoped)
            services.AddScoped<ICacheService, RedisCacheService>();
            services.AddScoped<ICacheLockManager, CacheLockManager>();
            services.AddScoped<IRateLimiter, RateLimiter>();
            services.AddScoped<ICacheHelper, CacheHelper>();

            // =========================================================
            // 📂 2. UNIT OF WORK & REPOSITORY REGISTRATION
            // =========================================================
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // Explicit Manual Registration for Custom Repositories (Corrected Namespace)
            //services.AddScoped<IDiscountRepository, DiscountRepository>();
            //services.AddScoped<IComboRepository, ComboRepository>();
            //services.AddScoped<ILandingPageRepository, LandingPageRepository>();

            var infrastructureAssembly = Assembly.GetExecutingAssembly();

            // 🚀 AUTOMATIC REPOSITORY REGISTRATION (For remaining repositories)
            var repositoryTypes = infrastructureAssembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith("Repository"));

            foreach (var implementationType in repositoryTypes)
            {
                var interfaceType = implementationType.GetInterfaces()
                    .FirstOrDefault(i => i.Name == $"I{implementationType.Name}");

                if (interfaceType != null)
                {
                    // Avoid duplicate service descriptor registration exceptions
                    if (!services.Any(s => s.ServiceType == interfaceType))
                    {
                        services.AddScoped(interfaceType, implementationType);
                    }
                }
            }

            // =========================================================
            // 🔑 3. PASSWORD HASHER & CORE SERVICES REGISTRATION
            // =========================================================
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            var serviceTypes = infrastructureAssembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith("Service"));

            foreach (var implementationType in serviceTypes)
            {
                var interfaceType = implementationType.GetInterfaces()
                    .FirstOrDefault(i => i.Name == $"I{implementationType.Name}");

                if (interfaceType != null &&
                    interfaceType != typeof(ISslCommerzService) &&
                    interfaceType != typeof(ICourierService) &&
                    interfaceType != typeof(ICacheService) &&
                    interfaceType != typeof(ISmsService))
                {
                    if (!services.Any(s => s.ServiceType == interfaceType))
                    {
                        services.AddScoped(interfaceType, implementationType);
                    }
                }
            }

            // =========================================================
            // 🌐 4. EXTERNAL HTTP SERVICES
            // =========================================================
            services.AddHttpClient<ISslCommerzService, SslCommerzService>();
            services.AddHttpClient<ICourierService, SteadfastCourierService>();

            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddScoped<IEmailService, EmailService>();

            services.AddSingleton<INotificationQueue, NotificationQueue>();
            services.AddHostedService<NotificationBackgroundWorker>();

            // =========================================================
            // 📱 5. SSL WIRELESS SMS SERVICE REGISTRATION
            // =========================================================
            services.Configure<SslWirelessSettings>(configuration.GetSection("SslWireless"));

            var sslEnabled = configuration.GetValue<bool>("SslWireless:Enabled");
            if (sslEnabled)
            {
                services.AddScoped<ISmsService, SslWirelessSmsService>();
            }
            else
            {
                services.AddScoped<ISmsService, NoOpSmsService>();
            }

            return services;
        }

        public static async Task<IApplicationBuilder> SeedDatabaseAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<ApplicationDbContext>();
                var passwordHasher = services.GetRequiredService<IPasswordHasher>();

                await DataSeeder.SeedAsync(context, passwordHasher);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<ApplicationDbContext>>();
                logger.LogError(ex, "An error occurred while seeding the database.");
            }

            return app;
        }
    }
}
