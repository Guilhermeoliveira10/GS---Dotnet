using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;  // Adicione esta linha
using SafeZone.Infrastructure.Context;
using System.IO;

namespace SafeZone.Infrastructure
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SafeZoneDbContext>
    {
        public SafeZoneDbContext CreateDbContext(string[] args)
        {
            // Cria a configuração a partir do appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Obtém a string de conexão
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Configura o DbContext para usar Oracle com a string de conexão
            var optionsBuilder = new DbContextOptionsBuilder<SafeZoneDbContext>();
            optionsBuilder.UseOracle(connectionString);

            return new SafeZoneDbContext(optionsBuilder.Options);
        }
    }
}
