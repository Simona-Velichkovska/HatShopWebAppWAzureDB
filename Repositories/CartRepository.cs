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
        public async Task<List<CartItems>> addHatInShoppingCart(Guid cartId, Guid hatId)
        {
            Hat hat = await hatShopDbContext.Hats.FindAsync(hatId);
            List<CartItems> cartItems = await this.findCartItemsByCartId(cartId);
            var itemCount = cartItems.Where(c => c.Hat.Equals(hat)).Count();
            CartItems cartItem = new CartItems();
            cartItem.Hat = hat;
            cartItem.CartId = cartId;

            if (itemCount == 0)
            {
                cartItem.Quantity = 1;
                await hatShopDbContext.CartItems.AddAsync(cartItem);
            }
            else
            {
                cartItems.Where(c => c.Hat.Equals(hat)).First().Quantity += 1;
            }
            
            await hatShopDbContext.SaveChangesAsync();
            return cartItems;
        }
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

        public async Task<List<CartItems>> findCartItemsByCartId(Guid cartId)
        {
            return await hatShopDbContext.CartItems.Where(c=>c.CartId==cartId).Include(h=>h.Hat).ToListAsync();
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