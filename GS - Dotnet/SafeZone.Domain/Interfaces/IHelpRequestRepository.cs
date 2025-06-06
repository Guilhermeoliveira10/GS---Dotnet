using SafeZone.Domain.Entities;

namespace SafeZone.Domain.Interfaces.Repositories
{
    public interface IHelpRequestRepository
    {
        Task<IEnumerable<HelpRequest>> GetAllAsync();
        Task<HelpRequest?> GetByIdAsync(int id);
        Task<HelpRequest> AddAsync(HelpRequest help);
        Task<HelpRequest> UpdateAsync(HelpRequest help);
        Task<bool> DeleteAsync(HelpRequest help);
    }
}
