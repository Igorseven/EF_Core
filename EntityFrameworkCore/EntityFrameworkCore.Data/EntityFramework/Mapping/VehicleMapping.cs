using EFCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Data.EntityFramework.Mapping
{
    public class VehicleMapping : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicles");
            builder.HasKey(v => v.Id).HasName("Pk_Vehicle");

            builder.Property(v => v.Model).HasColumnType("varchar(40)")
                .HasColumnName("Vehicle_Model").IsUnicode().IsRequired();

            builder.Property(v => v.Information).HasColumnType("varchar(150)")
                .HasColumnName("Vehicle_Information").IsUnicode().IsRequired();

            builder.Property(v => v.Price).HasColumnType("numeric").HasPrecision(12, 2)
                .HasColumnName("Vehicle_Price").IsRequired();

        }
    }
}
