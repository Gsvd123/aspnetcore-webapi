
using NZwalks.Api.Models.Domain;

namespace NZwalks.Api.Repositories
{
    public class InMemoryRegionRepository : IRegionRepository
    {
        public Task AddRegionAsync(Region region)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Region>> GetAllAsync()
        {
            var regionList=new List<Region>
            {
                new Region
                {
                    Id=Guid.NewGuid(),
                    Name="InMemory Sample",
                    Code="InMemory Code",
                    RegionImageUrl=""
                },
                 new Region
                {
                    Id=Guid.NewGuid(),
                    Name="InMemory Sample",
                    Code="InMemory Code",
                    RegionImageUrl=""
                }

            };

            return regionList;
        }

        public Task<Region> GetRegionAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task RemoveRegionAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRegionAsync(Guid Id, Region region)
        {
            throw new NotImplementedException();
        }

        Task<Region?> IRegionRepository.AddRegionAsync(Region region)
        {
            throw new NotImplementedException();
        }

        Task<Region?> IRegionRepository.RemoveRegionAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        Task<Region?> IRegionRepository.UpdateRegionAsync(Guid Id, Region region)
        {
            throw new NotImplementedException();
        }
    }
}