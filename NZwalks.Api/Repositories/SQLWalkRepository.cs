using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using NZwalks.Api.Data;
using NZwalks.Api.Models.Domain;

namespace NZwalks.Api.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly NZwalkDbContext dbContext;
        public SQLWalkRepository(NZwalkDbContext dbContext)
        {
            this.dbContext=dbContext;
        }
        public async Task<Walk?> CreateAsync(Walk walk)
        {
            if(walk==null){return null;}
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk?> DeleteWalkAsync(Guid id)
        {
           var walk= await dbContext.Walks.FirstOrDefaultAsync(x=>x.Id==id);
          if(walk==null)return null;
           dbContext.Walks.Remove(walk);
           await dbContext.SaveChangesAsync();
        return walk;
            
        }

     
        public async  Task<List<Walk>> GetAllWalksAsync(string? filterOn = null, string? filterQuery = null)
        {
            var walks=dbContext.Walks.Include("Difficulty").Include("Region").AsQueryable();
            
            //filtering 
            if(String.IsNullOrWhiteSpace(filterOn)==false && String.IsNullOrWhiteSpace(filterQuery)==false)
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                   walks= walks.Where(x=>x.Name.Contains(filterQuery));
                }

            else if (filterOn.Equals("Description", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Description.Contains(filterQuery));
                }
            };

             return  walks.ToList();
        }

        public async Task<Walk> GetWalkAsync(Guid id)
        {
            var walk=await dbContext.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x=>x.Id==id);
            if(walk==null){
                return null;
            }
            return walk;
        }

        public async Task<Walk?> UpdateWalkAsync(Guid id,Walk walk)
        {
           var existingItem=await dbContext.Walks.FirstOrDefaultAsync(x=>x.Id==id);

           if(existingItem==null)return null;

           existingItem.Name=walk.Name;
           existingItem.Description=walk.Description;
           existingItem.LengthInKm=walk.LengthInKm;
           existingItem.WalkImageUrl=walk.WalkImageUrl;
           existingItem.DifficultyId=walk.DifficultyId;
           existingItem.RegionId=walk.RegionId;

           await dbContext.SaveChangesAsync();

           return existingItem;
           
        }
    }
}