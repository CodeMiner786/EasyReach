using EasyReach.Middlewares;
using EasyReach_Application.DependencyInjections;
using EasyReach_Infrastructure.DependencyInjections;

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

            // 2. Add Swagger/Endpoints API Explorer
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // 3. Register Custom Application & Infrastructure DI Extensions 
            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);

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

            app.UseAuthorization();

            app.MapControllers();

            await app.RunAsync();
        }
    }
}
