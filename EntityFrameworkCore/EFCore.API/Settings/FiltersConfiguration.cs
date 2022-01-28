using AutoMapper.Configuration;
using EFCore.API.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace EFCore.API.Settings
{
    public static class FiltersConfiguration
    {
        public static void AddFiltersConfiguration(this IServiceCollection services, IConfiguration configuration = null)
        {
            services.AddMvc(config =>
            {
                config.Filters.AddService<GetNotificationFilter>();
            });



            services.AddScoped<GetNotificationFilter>();

        }
    }
}
