using Microsoft.AspNetCore.Mvc;
using SafeZone.Domain.Entities;
using SafeZone.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace SafeZone.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlertController : ControllerBase
{
    private readonly AlertRepository _repository;

    public AlertController(AlertRepository repository)
    {
        _repository = repository;
    }

    // GET: api/alert
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _repository.GetAllAsync());

    // GET: api/alert/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var alert = await _repository.GetByIdAsync(id);
        return alert is null ? NotFound() : Ok(alert);
    }

    // POST: api/alert
    [HttpPost]
    public async Task<IActionResult> Create(Alert alert)
    {
        await _repository.AddAsync(alert);
        return CreatedAtAction(nameof(Get), new { id = alert.Id }, alert);
    }

    // PUT: api/alert/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Alert alert)
    {
        if (id != alert.Id) return BadRequest();

        var existente = await _repository.GetByIdAsync(id);
        if (existente is null) return NotFound();

        existente.Titulo = alert.Titulo;
        existente.Tipo = alert.Tipo;
        existente.Data = alert.Data;

        await _repository.UpdateAsync(existente);
        return NoContent();
    }

    // DELETE: api/alert/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var alert = await _repository.GetByIdAsync(id);
        if (alert is null) return NotFound();

        await _repository.DeleteAsync(alert);
        return NoContent();
    }
}
