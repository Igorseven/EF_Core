using EFCore.Business.Interfaces.ValidationContext;
using EFCore.Business.Validation.Entities;
using EFCore.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace EFCore.IoC.ConfigurationDI
{
    public static class ValidationDIConfiguration
    {
        public static void AddValidationDI(this IServiceCollection services)
        {
            services.AddScoped<IValidation<Vehicle>, VehicleValidation>();
            services.AddScoped<IValidation<Manufacturer>, ManufacturerValidation>();
        }
    }
}
