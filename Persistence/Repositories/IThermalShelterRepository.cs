using CoolZoneAPI.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoolZoneAPI.Persistence.Repositories
{
    // A interface IThermalShelterRepository DEVE estender IRepository<ThermalShelter>
    public interface IThermalShelterRepository : IRepository<ThermalShelter>
    {
        Task<ThermalShelter?> GetByIdWithCityAsync(Guid id);
        Task<IEnumerable<ThermalShelter>> GetAllWithCityAsync();
    }
}
