using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NZwalks.Api.Data
{
    public class NZwalkDbContextFactory : IDesignTimeDbContextFactory<NZwalkDbContext>
    {
        public NZwalkDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<NZwalkDbContext>();

            optionsBuilder.UseSqlServer(
                "Server=localhost,1433;Database=NZWalksDb;User Id=sa;Password=Gokul@123;TrustServerCertificate=True;"
            );

            return new NZwalkDbContext(optionsBuilder.Options);
        }
    }
}