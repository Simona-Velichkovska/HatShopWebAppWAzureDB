using HatShopWebAppWAzureDB.Data;
using HatShopWebAppWAzureDB.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        public async Task<List<Hat>> FilterHats( List<Hat> hats,string size, string brand, string color, string stock)
        {
            if (!String.IsNullOrEmpty(size))
            {
                hats= hats.Where(h => h.Size.ToLower().Equals(size.ToLower())).ToList();
            }
            if(!String.IsNullOrEmpty(brand))
            {
                hats = hats.Where(h => h.Brand.ToLower().Equals(brand.ToLower())).ToList();
            }
            if (!String.IsNullOrEmpty(color))
            {
                hats = hats.Where(h => h.Color.ToLower().Equals(color.ToLower())).ToList();
            }
            if (!String.IsNullOrEmpty(stock) && stock.Equals("true"))
            {
                hats = hats.Where(h => h.InStock.ToString().ToLower().Equals(stock.ToLower())).ToList();
            }

            return hats;
        }

        public async Task<IEnumerable<Hat>> GetAllAsync()
        {
            return await hatShopDbContext.Hats.Where(h => h.Visible == true).ToListAsync();

        }

        public async Task<Hat> GetByIdAsync(Guid id)
        {
            return await hatShopDbContext.Hats.FindAsync(id);
        }

        public async Task<Int32> GetCountOfAllVisible()
        {
            return await hatShopDbContext.Hats.Where(h => h.Visible == true).CountAsync();
        }


        public async Task<List<Hat>> SearchByString(string search)
        {
            return await hatShopDbContext.Hats.Where(h => (h.Name.Contains(search) || h.Brand.Contains(search)) && h.Visible == true).ToListAsync();
        }

        public async Task<List<Hat>> TakeSomeAsync(int skip, int size)
        {
            return await hatShopDbContext.Hats.Where(h => h.Visible == true).Skip(skip).Take(size).ToListAsync();
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
