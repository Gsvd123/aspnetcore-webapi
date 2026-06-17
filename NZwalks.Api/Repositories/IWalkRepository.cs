
using NZwalks.Api.Models.Domain;

namespace NZwalks.Api.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk?> CreateAsync(Walk walk);
        Task<List<Walk>> GetAllWalksAsync(string? filterOn=null,string? filterQuery=null);
        Task<Walk> GetWalkAsync(Guid id);
        Task<Walk?> UpdateWalkAsync(Guid id,Walk walk);
        Task<Walk?> DeleteWalkAsync(Guid id);

    }
}