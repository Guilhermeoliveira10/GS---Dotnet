using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SafeZone.Infrastructure.Context;
using SafeZone.Infrastructure.Repositories;
using SafeZone.Application.Messaging;
using SafeZone.Application.ML; // ✅ Importante para injetar MLModelPredictor
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// CONFIGURAR DbContext com SQLite
builder.Services.AddDbContext<SafeZoneDbContext>(options =>
    options.UseSqlite("Data Source=safezone.db"));

// REPOSITÓRIOS
builder.Services.AddScoped<AlertRepository>();
builder.Services.AddScoped<HelpRequestRepository>();
builder.Services.AddScoped<RiskZoneRepository>();

// RABBITMQ PRODUCER
builder.Services.AddSingleton<RabbitMqProducer>();

// RATE LIMITING
builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("fixed", config =>
    {
        config.Window = TimeSpan.FromSeconds(10);
        config.PermitLimit = 5;
        config.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        config.QueueLimit = 2;
    });

    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
});

// ✅ CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();

// SWAGGER
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SafeZone API",
        Version = "v1",
        Description = "API para apoio a comunidades em eventos extremos"
    });

    var xmlFile = "SafeZone.API.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// PIPELINE
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRateLimiter();

// ✅ ATIVAR CORS
app.UseCors("AllowAll");

app.UseAuthorization();
app.MapControllers();
app.Run();

