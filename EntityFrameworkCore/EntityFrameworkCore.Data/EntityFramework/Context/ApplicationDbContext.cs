using EFCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Data.EntityFramework.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContext) : base (dbContext)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
