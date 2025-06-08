using Microsoft.EntityFrameworkCore;
using SafeZone.Domain.Entities;  // Certifique-se de importar as entidades do domínio

namespace SafeZone.Infrastructure.Context
{
    public class SafeZoneDbContext : DbContext
    {
        // DbSets para as entidades
        public DbSet<Alert> Alerts => Set<Alert>();
        public DbSet<HelpRequest> HelpRequests => Set<HelpRequest>();
        public DbSet<RiskZone> RiskZones => Set<RiskZone>();

        // Construtor para o DbContext
        public SafeZoneDbContext(DbContextOptions<SafeZoneDbContext> options)
            : base(options)
        {
        }

        // Configuração para o Oracle
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseOracle("User Id=rm554176;Password=180505;Data Source=oracle.fiap.com.br:1521/ORCL");
            }
        }
    }
}
