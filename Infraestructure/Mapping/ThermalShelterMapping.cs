using CoolZoneAPI.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoolZoneAPI.Infrastructure.Mapping
{
    public class ThermalShelterMapping : IEntityTypeConfiguration<ThermalShelter>
    {
        public void Configure(EntityTypeBuilder<ThermalShelter> builder)
        {
            builder.ToTable("THERMAL_SHELTERS");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                   .HasColumnName("ID")
                   .IsRequired();

            builder.Property(s => s.Name)
                   .HasColumnName("NAME")
                   .HasMaxLength(100)
                   .IsRequired(); // Adicione se for obrigatório

            builder.Property(s => s.Type)
                   .HasColumnName("TYPE")
                   .HasConversion<string>()
                   .IsRequired();

            builder.Property(s => s.Address)
                   .HasColumnName("ADDRESS")
                   .HasMaxLength(200)
                   .IsRequired(); // Adicione se for obrigatório

            builder.Property(s => s.Capacity)
                   .HasColumnName("CAPACITY")
                   .IsRequired();

            builder.Property(s => s.OpeningHours)
                   .HasColumnName("OPENING_HOURS")
                   .HasConversion<string>()
                   .IsRequired();

            builder.Property(s => s.CityId)
                   .HasColumnName("CITY_ID")
                   .IsRequired();

            builder.HasOne(s => s.City)
                   .WithMany(c => c.ThermalShelters)
                   .HasForeignKey(s => s.CityId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}