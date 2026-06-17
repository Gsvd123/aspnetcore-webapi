
using NZwalks.Api.Models.Domain;
using NZwalks.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace NZwalks.Api.Repositories{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly NZwalkDbContext nZwalkDbContext;
            public SQLRegionRepository(NZwalkDbContext nZwalkDbContext)
        {
        this.nZwalkDbContext=nZwalkDbContext;
        }

        public async Task<Region?> AddRegionAsync(Region region)
        {
            await nZwalkDbContext.Regions.AddAsync(region);
           await nZwalkDbContext.SaveChangesAsync();
            return region;
           
        }

        public async Task<Region?> GetRegionAsync(Guid Id)
        {
            var region=await nZwalkDbContext.Regions.FirstOrDefaultAsync(x=>x.Id==Id);
            
            return region;
        }

        public async Task RemoveAllAsync()
        {
           
         // nZwalkDbContext.Regions.RemoveRange(await GetAllAsync());
          await nZwalkDbContext.Regions.ExecuteDeleteAsync();
          await nZwalkDbContext.SaveChangesAsync();
        }

        public async Task<Region?> RemoveRegionAsync(Guid Id)
        {
            var region=await nZwalkDbContext.Regions.FirstOrDefaultAsync(x=>x.Id==Id);
            if (region == null)
            {
                return null;
            }
             nZwalkDbContext.Regions.Remove(region);
            await  nZwalkDbContext.SaveChangesAsync();
            return region;


        }

        public async Task<Region?> UpdateRegionAsync(Guid Id, Region region)
        {
            var existingRegion= await nZwalkDbContext.Regions.FirstOrDefaultAsync(x=>x.Id==Id);
            if (existingRegion == null)
            {
                return null;
            }
            existingRegion.Name=region.Name;
            existingRegion.Code=region.Code;
            existingRegion.RegionImageUrl=region.RegionImageUrl;

            await nZwalkDbContext.SaveChangesAsync();

            return existingRegion;
        }

        async Task<List<Region>> GetAllAsync()
        {
            return await nZwalkDbContext.Regions.ToListAsync();
        }

        Task<List<Region>> IRegionRepository.GetAllAsync()
        {
            return GetAllAsync();
        }
    }
}