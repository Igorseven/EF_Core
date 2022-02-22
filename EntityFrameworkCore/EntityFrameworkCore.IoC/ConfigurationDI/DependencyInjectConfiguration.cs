using EFCore.Business.Interfaces.NotificationContext;
using EFCore.Business.Interfaces.Repository;
using EFCore.Business.Interfaces.ValidationContext;
using EFCore.Business.NotificationSettings;
using EFCore.Business.Validation;
using EFCore.Data.EntityFramework.Context;
using EFCore.Data.Repository;
using EFCore.ServiceApplication.AutoMapperSettings;
using EFCore.ServiceApplication.Interfaces;
using EFCore.ServiceApplication.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EFCore.IoC.ConfigurationDI
{
    public static class DependencyInjectConfiguration
    {
        public static void AddDependencyInject(this IServiceCollection services, IConfiguration configuration = null)
        {

            services.AddDbContext<ApplicationDbContext>(config =>
            config.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ApplicationDbContext>();

            AutoMapperHandler.Inicialze();

            services.AddScoped<IDomainValidation, DomainValidation>();
            services.AddScoped<INotificationContext, NotificationContext>();

            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IManufacturerRepository, ManufacturerRepository>();

            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IManufacturerService, ManufacturerService>();

        }
    }
}
