using CoolZoneAPI.Domain.Entity;
using CoolZoneAPI.Infraestructure.Mapping;
using CoolZoneAPI.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace CoolZoneAPI.Infraestructure.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<ThermalShelter> ThermalShelters { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CityMapping());
            modelBuilder.ApplyConfiguration(new ThermalShelterMapping());
        }
    }
}
