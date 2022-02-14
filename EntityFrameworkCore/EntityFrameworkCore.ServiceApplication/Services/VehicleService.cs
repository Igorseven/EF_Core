using EFCore.Business.Interfaces.NotificationContext;
using EFCore.Business.Interfaces.Repository;
using EFCore.Business.Interfaces.ValidationContext;
using EFCore.Domain.Entities;
using EFCore.Domain.EntitiesValidation;
using EFCore.ServiceApplication.AutoMapperSettings;
using EFCore.ServiceApplication.Interfaces;
using EFCore.ServiceApplication.Request.Vehicle;
using EFCore.ServiceApplication.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.ServiceApplication.Services
{
    public class VehicleService : BaseService<Vehicle, VehicleValidation>, IVehicleService
    {
        private readonly IVehicleRepository _repository;

        public VehicleService(INotificationContext notification, IDomainValidation validation, IVehicleRepository repository)
            : base(notification, validation)
        {
            this._repository = repository;
        }

        public async Task CreatAsync(VehicleRequest request)
        {
            var vehicle = request.MapTo<VehicleRequest, Vehicle>();

            if (await ValidatedAsync(vehicle, new VehicleValidation()))
               await this._repository.CreatAsync(vehicle);
        }

        public async Task UpdateAsync(VehicleUpdateRequest request)
        {
            var vehicle = request.MapTo<VehicleUpdateRequest, Vehicle>();

            if (await ValidatedAsync(vehicle, new VehicleValidation()))
                await this._repository.UpdateAsync(vehicle);
        }

        public async Task DeleleByIdAsync(int id)
        {

            await this._repository.DeleteByIdAsync(id);
        }

        public async Task DeleteAsync(VehicleRequest request)
        {
            var vehicle = request.MapTo<VehicleRequest, Vehicle>();

            await this._repository.DeleteAsync(vehicle);
        }

        public async Task<VehicleResponse> FindByAsync(int id)
        {
            var vehicle = await this._repository.FindByAsync(id);

            var response = vehicle.MapTo<Vehicle, VehicleResponse>();

            return response;
        }

        public async Task<VehicleResponse> FindByAsync(VehicleRequest request)
        {
            var vehicle = await this._repository.FindByAsync(x => x.Model == request.Model);

            var response = vehicle.MapTo<Vehicle, VehicleResponse>();

            return response;
        }

        public async Task<IEnumerable<VehicleResponse>> FindAllAsync()
        {
            var vehicles = await this._repository.FindAllAsync();

            var responses = vehicles.MapTo<IEnumerable<Vehicle>, IEnumerable<VehicleResponse>>();

            return responses;
        }

        public async Task<IEnumerable<VehicleResponse>> GetAllVehiclesAndManufacturers()
        {
            var vehicles = await this._repository.GetAllVehiclesAndManufacturersAsync();

            var responses = vehicles.MapTo<IEnumerable<Vehicle>, IEnumerable<VehicleResponse>>();

            return responses;
        }

        public async Task<VehicleResponse> FindVehickeAndManufacturerAsync(int id)
        {
            var vehicle = await this._repository.GetVehicleAndManufacturerAsync(id);

            var response = vehicle.MapTo<Vehicle, VehicleResponse>();

            return response;
        }
    }
}
