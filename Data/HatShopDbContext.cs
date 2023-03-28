using HatShopWebAppWAzureDB.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HatShopWebAppWAzureDB.Data
{
    public class HatShopDbContext : DbContext
    {
        public HatShopDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Hat> Hats { get; set; }



    }
}
