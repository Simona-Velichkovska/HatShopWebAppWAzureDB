using Microsoft.EntityFrameworkCore;

namespace HatShopWebAppWAzureDB.Models.Domain
{
    public class CartItems
    {
        public Guid Id { get; set; }
        public Hat Hat { get; set; }
        public int Quantity { get; set; }
        public int TotalItems { get; set; }
    }
}
