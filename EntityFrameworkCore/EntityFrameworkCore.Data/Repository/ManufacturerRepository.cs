using EFCore.Business.Interfaces.Repository;
using EFCore.Data.EntityFramework.Context;
using EFCore.Domain.Entities;

namespace EFCore.Data.Repository
{
    public class ManufacturerRepository : BaseRepository<Manufacturer, int>, IManufacturerRepository
    {
        public ManufacturerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
