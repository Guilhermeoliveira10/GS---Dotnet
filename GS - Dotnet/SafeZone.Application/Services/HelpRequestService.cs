using SafeZone.Application.DTOs;
using SafeZone.Application.Interfaces;
using SafeZone.Domain.Entities;
using SafeZone.Domain.Interfaces.Repositories;
using SafeZone.Domain.Interfaces;

namespace SafeZone.Application.Services;

public class HelpRequestService : IHelpRequestService
{
    private readonly IHelpRequestRepository _repository;

    public HelpRequestService(IHelpRequestRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<HelpRequest>> ListAsync()
        => await _repository.GetAllAsync();

    public async Task<HelpRequest?> GetByIdAsync(int id)
        => await _repository.GetByIdAsync(id);

    public async Task<HelpRequest> CreateAsync(HelpRequestDto dto)
    {
        var helpRequest = new HelpRequest
        {
            Nome = dto.Title,
            TipoAjuda = dto.Description,
            DataSolicitacao = dto.Date,
            Localizacao = dto.UserEmail
        };

        return await _repository.AddAsync(helpRequest);
    }

    public async Task<HelpRequest?> UpdateAsync(int id, HelpRequestDto dto)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null) return null;

        existing.Nome = dto.Title;
        existing.TipoAjuda = dto.Description;
        existing.DataSolicitacao = dto.Date;
        existing.Localizacao = dto.UserEmail;

        return await _repository.UpdateAsync(existing);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null) return false;

        await _repository.DeleteAsync(existing);
        return true;
    }
}
