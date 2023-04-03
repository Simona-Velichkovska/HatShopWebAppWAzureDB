using HatShopWebAppWAzureDB.Identity;
using HatShopWebAppWAzureDB.Models.Domain;
using HatShopWebAppWAzureDB.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HatShopWebAppWAzureDB.Pages.Cart
{
    public class ShoppingCartModel : PageModel
    {
        private readonly ICartRepository cartRepository;
        private readonly UserManager<Identity.User> _userManager;

        public List<CartItems> cartItems { get; set; }
        public ShoppingCart cart { get; set; }

        public ShoppingCartModel(ICartRepository cartRepository, UserManager<Identity.User> userManager)
        {
            this.cartRepository = cartRepository;
            this._userManager = userManager;
        }

        public async Task OnGet()
        {
            if (HttpContext.User.Identity.Name != null)
            {
                Identity.User user = await _userManager.GetUserAsync(HttpContext.User);
                cart = await cartRepository.findShoppingCartByUserId(user.Id);
                cartItems = await cartRepository.findCartItemsByCartId(cart.Id);
            }
        }
    }
}