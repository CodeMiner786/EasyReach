using EasyReach_Application.Files;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.DependencyInjections
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            // ১. AutoMapper Registration
            services.AddAutoMapper(cfg => cfg.AddMaps(assembly)); // ✅ Fixed

            // ২. FluentValidation Registration (সব Validators স্বয়ংক্রিয়ভাবে পাবে)
            services.AddValidatorsFromAssembly(assembly);

            // ৩. MediatR Registration (CQRS Commands/Queries/Handlers পাবে)
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

            

            return services;
        }
    }
}