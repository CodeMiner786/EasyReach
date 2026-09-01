using EasyReach.Middlewares;
using EasyReach_Application.DependencyInjections;
using EasyReach_Infrastructure.DependencyInjections;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using System.Text.Json;

namespace EasyReach
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 🛠️ EF Core Migration-এর সময় DI Validation Error বন্ধ করার জন্য এই ৩ লাইন যোগ করা হয়েছে:
            builder.Host.UseDefaultServiceProvider(options =>
            {
                options.ValidateScopes = false;
                options.ValidateOnBuild = false;
            });

            // 1. Add API Controllers & OpenAPI
            builder.Services.AddControllers();
            builder.Services.AddOpenApi();

            // 2. Add Swagger/Endpoints API Explorer with Automatic Bearer JWT Support
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "EasyReach API",
                    Version = "v1"
                });

                // 🔐 Swagger UI-তে শুধু টোকেন দিলেই হবে, Bearer অটোমেটিক যোগ করার জন্য SecuritySchemeType.Http ব্যবহার করা হলো
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter your valid JWT token below. (No need to type 'Bearer', it will be added automatically)"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            // 3. Register Custom Application & Infrastructure DI Extensions 
            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);

            // 🔐 JWT Bearer Authentication-এর জন্য ইউজার-ফ্রেন্ডলি 401 & 403 Response Events কাস্টমাইজেশন
            builder.Services.PostConfigure<JwtBearerOptions>(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.Events ??= new JwtBearerEvents();

                // 401 Unauthorized (টোকেন না দিলে বা ইনভ্যালিড টোকেন দিলে)
                options.Events.OnChallenge = context =>
                {
                    context.HandleResponse();
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    context.Response.ContentType = "application/json";

                    var response = new
                    {
                        success = false,
                        message = "You are not authorized to access this resource. Please provide a valid JWT Token or Login first."
                    };

                    return context.Response.WriteAsync(JsonSerializer.Serialize(response));
                };

                // 403 Forbidden (অ্যাডমিন না হয়ে অ্যাডমিন এপিআইতে হিট করলে)
                options.Events.OnForbidden = context =>
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    context.Response.ContentType = "application/json";

                    var response = new
                    {
                        success = false,
                        message = "Access denied. You do not have permission (Admin role) to perform this action."
                    };

                    return context.Response.WriteAsync(JsonSerializer.Serialize(response));
                };
            });

            var app = builder.Build();

            // 🌱 Automatic Data Seeding Execution
            await app.SeedDatabaseAsync();

            // 4. Global Exception Handler Middleware 
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            // 5. Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();

                // Enable Swagger Middleware & Set Root URL to Swagger UI
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "EasyReach API v1");
                    c.RoutePrefix = string.Empty; // Root URL (/) এ সরাসরি Swagger লোড হবে
                });
            }

            app.UseHttpsRedirection();

            // 🔐 6. Authentication Middleware (Authorization এর আগে অবশ্যই থাকতে হবে)
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            await app.RunAsync();
        }
    }
}

