using Microsoft.EntityFrameworkCore;
using RunGroupWebApp.Data;
using RunGroupWebApp.Interfaces;
using RunGroupWebApp.Models;

namespace RunGroupWebApp.Repository
{
    public class RaceRepository : IRaceRepository
    {
        private readonly AppDbContext _context;
        public RaceRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Add(Races race)
        {
            _context.Races.Add(race);
            return Save();
        }

        public bool Delete(Races race)
        {
            _context.Races.Remove(race);
            return Save();
        }

        public async Task<IEnumerable<Races>> GetAll()
        {
            return await _context.Races.ToListAsync();
        }

        public async Task<IEnumerable<Races>> GetAllRacesByCity(string city)
        {
            return await _context.Races.Where(c => c.Address.City.Contains(city)).ToListAsync();
        }

        public async Task<Races> GetByIdAsync(int id)
        {
            return await _context.Races.Include(e => e.Address).FirstOrDefaultAsync(i => i.Id == id);
        }
        public async Task<Races> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Races.Include(e => e.Address).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false; 

        }

        public bool Update(Races race)
        {
            _context.Update(race);
            return Save();
        }
    }
}
