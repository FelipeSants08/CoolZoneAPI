using CoolZoneAPI.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoolZoneAPI.Infraestructure.Mapping
{
    public class CityMapping : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("CITIES");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                   .HasColumnName("ID")
                   .IsRequired();

            builder.Property(c => c.Name)
                   .HasColumnName("NAME")
                   .HasMaxLength(100)
                   .IsRequired(); // se for obrigatório

            builder.Property(c => c.State)
                   .HasColumnName("STATE")
                   .HasMaxLength(100)
                   .IsRequired(); // idem acima

            builder.HasMany(c => c.ThermalShelters)
                   .WithOne(s => s.City)
                   .HasForeignKey(s => s.CityId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
