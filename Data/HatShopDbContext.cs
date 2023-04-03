using HatShopWebAppWAzureDB.Identity;
using HatShopWebAppWAzureDB.Models.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HatShopWebAppWAzureDB.Data
{
    public class HatShopDbContext : IdentityDbContext<User>
    {
        public HatShopDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Hat> Hats { get; set; }



    }
}
