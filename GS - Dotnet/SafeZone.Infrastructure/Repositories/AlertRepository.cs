using SafeZone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SafeZone.Infrastructure.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SafeZone.Infrastructure.Repositories
{
    public class AlertRepository
    {
        private readonly SafeZoneDbContext _context;

        public AlertRepository(SafeZoneDbContext context)
        {
            _context = context;
        }

        public async Task<List<Alert>> GetAllAsync()
        {
            return await _context.Alerts.ToListAsync();
        }

        public async Task<Alert?> GetByIdAsync(int id)
        {
            return await _context.Alerts.FindAsync(id);
        }

        public async Task AddAsync(Alert alert)
        {
            _context.Alerts.Add(alert);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Alert alert)
        {
            _context.Alerts.Update(alert);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Alert alert)
        {
            _context.Alerts.Remove(alert);
            await _context.SaveChangesAsync();
        }
    }
}
