
using NZwalks.Api.Models.Domain;

namespace NZwalks.Api.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
        Task<Region?> GetRegionAsync(Guid Id);
        Task<Region?> AddRegionAsync(Region region);
        Task<Region?> UpdateRegionAsync(Guid Id,Region region);
        Task<Region?> RemoveRegionAsync(Guid Id);
        Task RemoveAllAsync();
        
    }
}