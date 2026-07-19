
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZwalks.Api.Data
{
    public class NZwalksAuthDbContext : IdentityDbContext
    {
        public NZwalksAuthDbContext(DbContextOptions<NZwalksAuthDbContext> options) : base(options)
        {
            
        }

        //seeding data Roles
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            
        }
    }
}