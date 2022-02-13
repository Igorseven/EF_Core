using EFCore.ServiceApplication.Request.Vehicle;
using EFCore.ServiceApplication.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.ServiceApplication.Interfaces
{
    public interface IVehicleService
    {
        Task CreatAsync(VehicleRequest request);
        Task UpdateAsync(VehicleUpdateRequest request);
        Task DeleleByIdAsync(int id);
        Task DeleteAsync(VehicleRequest request);
        Task<VehicleResponse> FindByAsync(int id);
        Task<VehicleResponse> FindByAsync(VehicleRequest request);
        Task<VehicleResponse> FindVehickeAndManufacturerAsync(int id);
        Task<IEnumerable<VehicleResponse>> FindAllAsync();
        Task<IEnumerable<VehicleResponse>> GetAllVehiclesAndManufacturers();
    }
}
