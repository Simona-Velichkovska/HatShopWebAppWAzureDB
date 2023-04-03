using HatShopWebAppWAzureDB.Data;
using HatShopWebAppWAzureDB.Identity;
using HatShopWebAppWAzureDB.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NuGet.Versioning;

namespace HatShopWebAppWAzureDB.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly HatShopDbContext hatShopDbContext;

        public CartRepository(HatShopDbContext hatShopDbContext)
        {
            this.hatShopDbContext = hatShopDbContext;
        }

        //Service function
/*        public async Task<ShoppingCart> addHatInShoppingCart(Guid cartId, Guid hatId)
        {
            Hat hat = await hatShopDbContext.Hats.FindAsync(hatId);
            ShoppingCart cart = await hatShopDbContext.shoppingCarts.FindAsync(cartId);


            await hatShopDbContext.SaveChangesAsync();
            return cart;

            throw new NotImplementedException();
        }*/
        //Service function
        public async Task<ShoppingCart> createShoppingCartForUser(string userId)
        {
            User user = await hatShopDbContext.Users.FindAsync(userId);
            ShoppingCart cart = new ShoppingCart();
            cart.User = user;
            cart.DateCreated= DateTime.Now;
            await hatShopDbContext.shoppingCarts.AddAsync(cart);
            await hatShopDbContext.SaveChangesAsync();
            return cart;
        }

        public async Task<CartItems> findCartItemsById(Guid id)
        {
            return await hatShopDbContext.CartItems.FindAsync(id);
        }

        public async Task<ShoppingCart> findShoppingCartById(Guid id)
        {
            return await hatShopDbContext.shoppingCarts.FindAsync(id);
        }

        public async Task<ShoppingCart> findShoppingCartByUserId(string userId)
        {
            if (!hatShopDbContext.shoppingCarts.IsNullOrEmpty())
            {
                return await hatShopDbContext.shoppingCarts.Where(s => s.User.Id.Equals(userId)).FirstAsync<ShoppingCart>();
            }
            else
            {
                return null;
            }
        }
    }
}