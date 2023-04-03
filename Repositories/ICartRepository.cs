using HatShopWebAppWAzureDB.Models.Domain;

namespace HatShopWebAppWAzureDB.Repositories
{
    public interface ICartRepository
    {
        Task<ShoppingCart> findShoppingCartById(Guid id);
        Task<ShoppingCart> findShoppingCartByUserId(string userId);
        Task<ShoppingCart> createShoppingCartForUser(string userId);
        //Task<ShoppingCart> addHatInShoppingCart(Guid cartId, Guid hatId);
        Task<CartItems> findCartItemsById(Guid id);

    }
}