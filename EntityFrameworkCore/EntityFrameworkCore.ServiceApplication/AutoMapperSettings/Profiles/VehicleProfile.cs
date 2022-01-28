using AutoMapper;
using EFCore.Domain.Entities;
using EFCore.ServiceApplication.Request.Vehicle;
using EFCore.ServiceApplication.Response;

namespace EFCore.ServiceApplication.AutoMapperSettings.Profiles
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<Vehicle, VehicleRequest>()
                .ForMember(vr => vr.ManufacturerRequest, map => map.MapFrom(v => v.Manufacturer))
                .ReverseMap()
                .ForPath(v => v.Manufacturer, map => map.MapFrom(vr => vr.ManufacturerRequest));

            CreateMap<Vehicle, VehicleUpdateRequest>()
                .ForMember(vu => vu.ManufacturerUpdateRequest, map => map.MapFrom(v => v.Manufacturer))
                .ReverseMap()
                .ForPath(v => v.Manufacturer, map => map.MapFrom(vu => vu.ManufacturerUpdateRequest));

            CreateMap<Vehicle, VehicleResponse>()
                .ForMember(vr => vr.ManufacturerResponse, map => map.MapFrom(v => v.Manufacturer))
                .ReverseMap()
                .ForPath(v => v.Manufacturer, map => map.MapFrom(vr => vr.ManufacturerResponse));
        }
    }
}
