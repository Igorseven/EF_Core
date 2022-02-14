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
                .ForMember(vr => vr.ManufacturerId, map => map.MapFrom(v => v.ManufacturerId))
                .ReverseMap()
                .ForPath(v => v.ManufacturerId, map => map.MapFrom(vr => vr.ManufacturerId));

            CreateMap<Vehicle, VehicleUpdateRequest>()
                .ForMember(vr => vr.ManufacturerId, map => map.MapFrom(v => v.ManufacturerId))
                .ReverseMap()
                .ForPath(v => v.ManufacturerId, map => map.MapFrom(vr => vr.ManufacturerId));

            CreateMap<Vehicle, VehicleResponse>()
                .ForMember(vr => vr.ManufacturerResponse, map => map.MapFrom(v => v.Manufacturer))
                .ReverseMap()
                .ForPath(v => v.Manufacturer, map => map.MapFrom(vr => vr.ManufacturerResponse));
        }
    }
}
