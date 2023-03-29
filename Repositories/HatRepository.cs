using HatShopWebAppWAzureDB.Data;
using HatShopWebAppWAzureDB.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HatShopWebAppWAzureDB.Repositories
{
    public class HatRepository : IHatRepository
    {
        private readonly HatShopDbContext hatShopDbContext;

        public HatRepository(HatShopDbContext hatShopDbContext)
        {
            this.hatShopDbContext = hatShopDbContext;
        }
        public async Task<Hat> AddAsync(Hat hat)
        {
            await hatShopDbContext.Hats.AddAsync(hat);
            await hatShopDbContext.SaveChangesAsync();
            return hat;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var currHat = await hatShopDbContext.Hats.FindAsync(id);
            if (currHat != null)
            {
                hatShopDbContext.Hats.Remove(currHat);
                await hatShopDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Hat>> GetAllAsync()
        {
            return await hatShopDbContext.Hats.ToListAsync();
            
        }

        public async Task<Hat> GetByIdAsync(Guid id)
        {
            return await hatShopDbContext.Hats.FindAsync(id);
        }

        public async Task<Hat> UpdateAsync(Hat hat)
        {
            var newHat = await hatShopDbContext.Hats.FindAsync(hat.Id);
            if (newHat != null)
            {
                newHat.Name = hat.Name;
                newHat.Description = hat.Description;
                newHat.InStock = hat.InStock;
                newHat.Color = hat.Color;
                newHat.Size = hat.Size;
                newHat.Brand = hat.Brand;
                newHat.Quantity = hat.Quantity;
                newHat.Price = hat.Price;
                newHat.FeaturedImageUrl = hat.FeaturedImageUrl;
                newHat.UrlHandle = hat.UrlHandle;
                newHat.Visible = hat.Visible;
            }

            await hatShopDbContext.SaveChangesAsync();
            return newHat;
        }
    }
}
