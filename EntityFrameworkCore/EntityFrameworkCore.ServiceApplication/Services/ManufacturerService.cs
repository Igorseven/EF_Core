using EFCore.Business.Interfaces.NotificationContext;
using EFCore.Business.Interfaces.Repository;
using EFCore.Business.Interfaces.ValidationContext;
using EFCore.Domain.Entities;
using EFCore.Domain.EntitiesValidation;
using EFCore.ServiceApplication.AutoMapperSettings;
using EFCore.ServiceApplication.Interfaces;
using EFCore.ServiceApplication.Request.Manufacturer;
using EFCore.ServiceApplication.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.ServiceApplication.Services
{
    public class ManufacturerService : BaseService, IManufacturerService
    {
        private readonly IManufacturerRepository _repository;

        public ManufacturerService(INotificationContext notification, IDomainValidation validation, IManufacturerRepository repository)
            : base(notification, validation)
        {
            this._repository = repository;
        }

        public async Task CreateAsync(ManufacturerRequest request)
        {
            var manufacturer = request.MapTo<ManufacturerRequest, Manufacturer>();

            if(await ValidatedAsync(manufacturer, new ManufacturerValidation()))
            {
                await this._repository.CreatAsync(manufacturer);
            }
        }

        public async Task UpdateAsync(ManufacturerUpdateRequest request)
        {
            var manufacturer = request.MapTo<ManufacturerUpdateRequest, Manufacturer>();

            if (await ValidatedAsync(manufacturer, new ManufacturerValidation()))
            {
                await this._repository.UpdateAsync(manufacturer);
            }
        }

        public async Task DeleleByIdAsync(int id)
        {
            await this._repository.DeleteByIdAsync(id);
        }

        public async Task DeleteAsync(ManufacturerRequest request)
        {
            var manufacturer = request.MapTo<ManufacturerRequest, Manufacturer>();

            await this._repository.DeleteAsync(manufacturer);
        }

        public async Task<ManufacturerResponse> FindByAsync(int id)
        {
            var manufacturer = await this._repository.FindByAsync(id);

            var response = manufacturer.MapTo<Manufacturer, ManufacturerResponse>();

            return response;
        }

        public async Task<ManufacturerResponse> FindByAsync(ManufacturerRequest request)
        {
            var manufacturer = await this._repository.FindByAsync(x => x.Name == request.Name);

            var response = manufacturer.MapTo<Manufacturer, ManufacturerResponse>();

            return response;
        }
        public async Task<IEnumerable<ManufacturerResponse>> FindAllAsync()
        {
            var manufacturers = await this._repository.FindAllAsync();

            var responses = manufacturers.MapTo<IEnumerable<Manufacturer>, IEnumerable<ManufacturerResponse>>();

            return responses;
        }

    }
}
