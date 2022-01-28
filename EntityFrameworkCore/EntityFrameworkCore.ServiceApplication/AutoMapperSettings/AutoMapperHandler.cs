using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace EFCore.ServiceApplication.AutoMapperSettings
{
    public static class AutoMapperHandler
    {
        public static IMapper Mapper { get; private set; }
        public static MapperConfiguration MapperConfiguration { get; private set; }


        public static void Inicialze()
        {
            MapperConfiguration = new MapperConfiguration(config =>
            {
                var profiles = Assembly.GetExecutingAssembly()
                .GetExportedTypes().Where(p => p.IsClass && typeof(Profile).IsAssignableFrom(p));

                foreach (var profile in profiles)
                {
                    config.AddProfile((Profile)Activator.CreateInstance(profile));
                };
            });

            Mapper = MapperConfiguration.CreateMapper();
        }
    }
}
