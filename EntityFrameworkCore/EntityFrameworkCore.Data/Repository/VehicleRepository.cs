using EFCore.Business.Interfaces.Repository;
using EFCore.Data.EntityFramework.Context;
using EFCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.Data.Repository
{
    public class VehicleRepository : BaseRepository<Vehicle, int>, IVehicleRepository
    {

        public VehicleRepository(ApplicationDbContext dbContext) : base (dbContext)
        {
            this._dbContext = dbContext;
        }

        public virtual async Task<IEnumerable<Vehicle>> GetAllVehiclesAndManufacturers()
        {
            return await this._dbContext.Vehicles.Include(m => m.Manufacturer.Name).AsNoTracking().ToListAsync();
        }
    }
}
