using Microsoft.EntityFrameworkCore;
using SafeZone.Infrastructure.Context;
using Microsoft.OpenApi.Models;
using SafeZone.Infrastructure.Repositories; // 👈 Importar os repositórios

var builder = WebApplication.CreateBuilder(args);

// CONFIGURAR DbContext com SQLite
builder.Services.AddDbContext<SafeZoneDbContext>(options =>
    options.UseSqlite("Data Source=safezone.db"));

// REGISTRAR REPOSITÓRIOS
builder.Services.AddScoped<AlertRepository>();
builder.Services.AddScoped<HelpRequestRepository>();
builder.Services.AddScoped<RiskZoneRepository>();

// CONFIGURAR CONTROLLERS
builder.Services.AddControllers();

// CONFIGURAR SWAGGER COM COMENTÁRIOS XML
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SafeZone API",
        Version = "v1",
        Description = "API para apoio a comunidades em eventos extremos"
    });

    // Comentários XML (documentação de métodos)
    var xmlFile = "SafeZone.API.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

// 🚧 (OPCIONAL - PRÓXIMAS ETAPAS)
// builder.Services.AddMemoryCache(); // Para RateLimit
// builder.Services.Configure<IpRateLimitOptions>(...); // Para RateLimit
// builder.Services.AddInMemoryRateLimiting();
// builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

var app = builder.Build();

// CONFIGURAR PIPELINE HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// app.UseIpRateLimiting(); // Rate Limit (se configurado)
app.UseAuthorization();

app.MapControllers(); // ATIVA OS CONTROLLERS

app.Run();
    