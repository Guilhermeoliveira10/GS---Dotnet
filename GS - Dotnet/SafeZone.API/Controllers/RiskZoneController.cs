using Microsoft.AspNetCore.Mvc;
using SafeZone.Domain.Entities;
using SafeZone.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace SafeZone.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RiskZoneController : ControllerBase
{
    private readonly RiskZoneRepository _repository;

    public RiskZoneController(RiskZoneRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _repository.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var zone = await _repository.GetByIdAsync(id);
        return zone is null ? NotFound() : Ok(zone);
    }

    [HttpPost]
    public async Task<IActionResult> Create(RiskZone riskZone)
    {
        await _repository.AddAsync(riskZone);
        return CreatedAtAction(nameof(Get), new { id = riskZone.Id }, riskZone);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, RiskZone riskZone)
    {
        if (id != riskZone.Id) return BadRequest();

        var existente = await _repository.GetByIdAsync(id);
        if (existente is null) return NotFound();

        existente.Local = riskZone.Local;
        existente.NivelRisco = riskZone.NivelRisco;
        existente.Latitude = riskZone.Latitude;
        existente.Longitude = riskZone.Longitude;

        await _repository.UpdateAsync(existente);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var zone = await _repository.GetByIdAsync(id);
        if (zone is null) return NotFound();

        await _repository.DeleteAsync(zone);
        return NoContent();
    }
}
