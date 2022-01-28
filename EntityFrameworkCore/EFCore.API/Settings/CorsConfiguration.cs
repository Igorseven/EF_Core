using AutoMapper.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EFCore.API.Settings
{
    public static class CorsConfiguration
    {
        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services, IConfiguration configuration = null)
        {

            services.AddCors(config => config.AddPolicy(name: "default", config =>
            
                config.WithOrigins("http://localhost:4200;")
                .AllowAnyHeader()
                .AllowAnyMethod()
            ));

            return services;
        }
    }
}
