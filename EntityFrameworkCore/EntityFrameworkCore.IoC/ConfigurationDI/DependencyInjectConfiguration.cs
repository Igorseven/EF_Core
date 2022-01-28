﻿using EFCore.Business.Interfaces.NotificationContext;
using EFCore.Business.Interfaces.Repository;
using EFCore.Business.Interfaces.ValidationContext;
using EFCore.Business.NotificationSettings;
using EFCore.Business.Validation.Entities;
using EFCore.Data.EntityFramework.Context;
using EFCore.Data.Repository;
using EFCore.Domain.Entities;
using EFCore.ServiceApplication.AutoMapperSettings.Profiles;
using EFCore.ServiceApplication.Interfaces;
using EFCore.ServiceApplication.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EFCore.IoC.ConfigurationDI
{
    public static class DependencyInjectConfiguration
    {
        public static void AddDependencyInject(this IServiceCollection services, IConfiguration configuration = null)
        {

            services.AddDbContext<ApplicationDbContext>(config =>
            config.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ApplicationDbContext>();

            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IManufacturerRepository, ManufacturerRepository>();

            services.AddScoped<IValidation<Vehicle>, VehicleValidation>();
            services.AddScoped<IValidation<Manufacturer>, ManufacturerValidation>();

            services.AddScoped<INotificationContext, NotificationContext>();
            
            services.AddAutoMapper(typeof(ManufacturerProfile), typeof(VehicleProfile));

            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IManufacturerService, ManufacturerService>();

        }
    }
}
