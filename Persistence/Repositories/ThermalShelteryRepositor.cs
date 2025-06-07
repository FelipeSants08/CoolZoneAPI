using CoolZoneAPI.Domain.Entity;
using CoolZoneAPI.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolZoneAPI.Persistence.Repositories
{
    
    public class ThermalShelterRepository : Repository<ThermalShelter>, IThermalShelterRepository 
    {
        private readonly AppDbContext _context; 

        public ThermalShelterRepository(AppDbContext context) : base(context)
        {
            _context = context; 
        }

        
        public async Task<ThermalShelter?> GetByIdWithCityAsync(Guid id)
        {
            return await _context.Set<ThermalShelter>()
                                 .Include(ts => ts.City) 
                                 .FirstOrDefaultAsync(ts => ts.Id == id);
        }

        
        public async Task<IEnumerable<ThermalShelter>> GetAllWithCityAsync()
        {
            return await _context.Set<ThermalShelter>()
                                 .Include(ts => ts.City) 
                                 .ToListAsync();
        }

       
    }
}
