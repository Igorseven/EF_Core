using EFCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Data.EntityFramework.Mapping
{
    public class ManufacturerMapping : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.ToTable("Manufactureres");
            builder.HasKey(m => m.Id).HasName("Pk_Manufacturer");

            builder.HasIndex(m => m.Name).IsUnique();
            builder.Property(m => m.Name).HasColumnType("varchar(50)")
                .HasColumnName("Manufacturer_Name").IsUnicode().IsRequired();
        }
    }
}
