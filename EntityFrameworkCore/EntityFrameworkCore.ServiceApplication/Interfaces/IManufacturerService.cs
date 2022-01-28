using EFCore.ServiceApplication.Request.Manufacturer;
using EFCore.ServiceApplication.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.ServiceApplication.Interfaces
{
    public interface IManufacturerService
    {
        Task CreateAsync(ManufacturerRequest request);
        Task UpdateAsync(ManufacturerUpdateRequest request);
        Task DeleleByIdAsync(int id);
        Task DeleteAsync(ManufacturerRequest request);
        Task<ManufacturerResponse> FindByAsync(int id);
        Task<ManufacturerResponse> FindByAsync(ManufacturerRequest request);
        Task<IEnumerable<ManufacturerResponse>> FindAllAsync();

    }
}
