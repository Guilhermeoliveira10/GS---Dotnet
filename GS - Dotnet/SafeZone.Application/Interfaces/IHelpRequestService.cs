using SafeZone.Application.DTOs;
using SafeZone.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SafeZone.Application.Interfaces;

public interface IHelpRequestService
{
    Task<IEnumerable<HelpRequest>> ListAsync();
    Task<HelpRequest?> GetByIdAsync(int id);
    Task<HelpRequest> CreateAsync(HelpRequestDto dto);
    Task<HelpRequest?> UpdateAsync(int id, HelpRequestDto dto);
    Task<bool> DeleteAsync(int id);
}
