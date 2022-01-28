using EFCore.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.Business.Interfaces.Repository
{
    public interface IVehicleRepository : IBaseRepository<Vehicle, int>
    {
        Task<IEnumerable<Vehicle>> GetAllVehiclesAndManufacturers();
    }
}
