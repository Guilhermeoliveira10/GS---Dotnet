using Microsoft.AspNetCore.Mvc;
using SafeZone.Domain.Entities;
using SafeZone.Infrastructure.Repositories;
using SafeZone.API.Models;
using SafeZone.Application.Messaging; // ✅ Importante!

namespace SafeZone.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelpRequestController : ControllerBase
{
    private readonly HelpRequestRepository _repository;
    private readonly RabbitMqProducer _rabbitMqProducer; // ✅ Novo

    public HelpRequestController(HelpRequestRepository repository, RabbitMqProducer rabbitMqProducer)
    {
        _repository = repository;
        _rabbitMqProducer = rabbitMqProducer;
    }

    private HelpRequestModel CreateLinks(HelpRequest help)
    {
        return new HelpRequestModel
        {
            Id = help.Id,
            Nome = help.Nome,
            TipoAjuda = help.TipoAjuda,
            Localizacao = help.Localizacao,
            DataSolicitacao = help.DataSolicitacao,
            Links = new List<LinkModel>
            {
                new LinkModel
                {
                    Href = Url.Action(nameof(Get), new { id = help.Id }) ?? "",
                    Rel = "self",
                    Method = "GET"
                },
                new LinkModel
                {
                    Href = Url.Action(nameof(Update), new { id = help.Id }) ?? "",
                    Rel = "update",
                    Method = "PUT"
                },
                new LinkModel
                {
                    Href = Url.Action(nameof(Delete), new { id = help.Id }) ?? "",
                    Rel = "delete",
                    Method = "DELETE"
                }
            }
        };
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var list = await _repository.GetAllAsync();
        var result = list.Select(CreateLinks);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var help = await _repository.GetByIdAsync(id);
        if (help is null) return NotFound();

        var result = CreateLinks(help);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(HelpRequest help)
    {
        await _repository.AddAsync(help);

        // ✅ Enviar mensagem para RabbitMQ
        _rabbitMqProducer.SendMessage(help);

        return CreatedAtAction(nameof(Get), new { id = help.Id }, CreateLinks(help));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, HelpRequest help)
    {
        if (id != help.Id) return BadRequest();

        var existente = await _repository.GetByIdAsync(id);
        if (existente is null) return NotFound();

        existente.Nome = help.Nome;
        existente.TipoAjuda = help.TipoAjuda;
        existente.Localizacao = help.Localizacao;
        existente.DataSolicitacao = help.DataSolicitacao;

        await _repository.UpdateAsync(existente);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var help = await _repository.GetByIdAsync(id);
        if (help is null) return NotFound();

        await _repository.DeleteAsync(help);
        return NoContent();
    }
}
