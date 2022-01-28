using AutoMapper;
using EFCore.Domain.Entities;
using EFCore.ServiceApplication.Request.Manufacturer;
using EFCore.ServiceApplication.Response;

namespace EFCore.ServiceApplication.AutoMapperSettings.Profiles
{
    public class ManufacturerProfile : Profile
    {
        public ManufacturerProfile()
        {
            CreateMap<Manufacturer, ManufacturerRequest>().ReverseMap();
            CreateMap<Manufacturer, ManufacturerUpdateRequest>().ReverseMap();
            CreateMap<Manufacturer, ManufacturerResponse>().ReverseMap();
        }
    }
}
