using Microsoft.EntityFrameworkCore;
using SafeZone.Domain.Entities;
using SafeZone.Infrastructure.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SafeZone.Infrastructure.Repositories
{
    public class RiskZoneRepository
    {
        private readonly SafeZoneDbContext _context;

        public RiskZoneRepository(SafeZoneDbContext context)
        {
            _context = context;
        }

        public async Task<List<RiskZone>> GetAllAsync()
        {
            return await _context.RiskZones.ToListAsync();
        }

        public async Task<RiskZone?> GetByIdAsync(int id)
        {
            return await _context.RiskZones.FindAsync(id);
        }

        public async Task AddAsync(RiskZone riskZone)
        {
            _context.RiskZones.Add(riskZone);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RiskZone riskZone)
        {
            _context.RiskZones.Update(riskZone);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(RiskZone riskZone)
        {
            _context.RiskZones.Remove(riskZone);
            await _context.SaveChangesAsync();
        }
    }
}
