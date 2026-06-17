using Microsoft.EntityFrameworkCore;
using NZwalks.Api.Models.Domain;

namespace NZwalks.Api.Data
{
    public class NZwalkDbContext : DbContext
    {
        public NZwalkDbContext(DbContextOptions<NZwalkDbContext> options)
            : base(options)
        {
        }

        public DbSet<Walk> Walks { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var Difficulties=new List<Difficulty>
            {
                new Difficulty
                {
                    Id=Guid.Parse("6246e4b9-da4f-4e83-a778-51ac742524e2"),
                    Name="Easy"

                },
                new Difficulty
                {
                    Id=Guid.Parse("84b58f3c-2e20-4809-8a5d-2a1d1c55d635"),
                    Name="Medium"
                },
                new Difficulty
                {
                    Id=Guid.Parse("79a6253b-eb78-4168-988d-611a62e2ed40"),
                    Name="Hard"
                }
            };

            var regions=new List<Region>
            {
                new Region
                {
                    Id=Guid.Parse("c4161cb1-52ba-413d-a8f4-bd2800efb54d"),
                    Name="Gobi",
                    Code="TN36",
                    RegionImageUrl="https//gobi.com"
                },
                new Region
                {
                    Id=Guid.Parse("969cf319-f21a-4ff4-835b-808cb932186f"),
                    Name="Coimbatore",
                    Code="TN37",
                    RegionImageUrl="https//Coimbatore.com"
                },
                new Region
                {
                    Id=Guid.Parse("1c43f593-c3fc-4d94-9a49-73081532ce9f"),
                    Name="Erode",
                    Code="TN56",
                    RegionImageUrl="https//Erode.com"
                },
                new Region
                {
                    Id=Guid.Parse("bfa37282-a3df-47da-bb43-6eee646c023b"),
                    Name="Tripur",
                    Code="TN58",
                    RegionImageUrl="https//Tripur.com"
                },
                new Region
                {
                    Id=Guid.Parse("869af7ca-0ccc-455f-b934-1bf0524c38c5"),
                    Name="Perundurai",
                    Code="TN56",
                    RegionImageUrl="https//Perundurai.com"
                },

            };

            modelBuilder.Entity<Difficulty>().HasData(Difficulties);
            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
