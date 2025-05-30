using Microsoft.AspNetCore.Mvc;
using SafeZone.Domain.Entities;
using SafeZone.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace SafeZone.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelpRequestController : ControllerBase
{
    private readonly HelpRequestRepository _repository;

    public HelpRequestController(HelpRequestRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _repository.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var helpRequest = await _repository.GetByIdAsync(id);
        return helpRequest is null ? NotFound() : Ok(helpRequest);
    }

    [HttpPost]
    public async Task<IActionResult> Create(HelpRequest helpRequest)
    {
        await _repository.AddAsync(helpRequest);
        return CreatedAtAction(nameof(Get), new { id = helpRequest.Id }, helpRequest);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, HelpRequest helpRequest)
    {
        if (id != helpRequest.Id) return BadRequest();
        await _repository.UpdateAsync(helpRequest);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var helpRequest = await _repository.GetByIdAsync(id);
        if (helpRequest is null) return NotFound();
        await _repository.DeleteAsync(helpRequest);
        return NoContent();
    }
}
