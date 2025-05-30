using Microsoft.EntityFrameworkCore;
using SafeZone.Domain.Entities;

namespace SafeZone.Infrastructure.Context;

public class SafeZoneDbContext : DbContext
{
    public DbSet<Alert> Alerts => Set<Alert>();
    public DbSet<HelpRequest> HelpRequests => Set<HelpRequest>();
    public DbSet<RiskZone> RiskZones => Set<RiskZone>();

    public SafeZoneDbContext(DbContextOptions<SafeZoneDbContext> options)
        : base(options)
    {
    }
}
