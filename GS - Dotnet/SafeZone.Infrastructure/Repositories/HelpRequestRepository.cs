using Microsoft.EntityFrameworkCore;
using SafeZone.Domain.Entities;
using SafeZone.Infrastructure.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SafeZone.Infrastructure.Repositories
{
    public class HelpRequestRepository
    {
        private readonly SafeZoneDbContext _context;

        public HelpRequestRepository(SafeZoneDbContext context)
        {
            _context = context;
        }

        public async Task<List<HelpRequest>> GetAllAsync()
        {
            return await _context.HelpRequests.ToListAsync();
        }

        public async Task<HelpRequest?> GetByIdAsync(int id)
        {
            return await _context.HelpRequests.FindAsync(id);
        }

        public async Task AddAsync(HelpRequest helpRequest)
        {
            _context.HelpRequests.Add(helpRequest);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(HelpRequest helpRequest)
        {
            _context.HelpRequests.Update(helpRequest);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(HelpRequest helpRequest)
        {
            _context.HelpRequests.Remove(helpRequest);
            await _context.SaveChangesAsync();
        }
    }
}
