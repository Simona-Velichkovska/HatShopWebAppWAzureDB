using Microsoft.EntityFrameworkCore;

namespace HatShopWebAppWAzureDB.Models.Domain
{
    public class CartItems
    {
        public Guid Id { get; set; }
        public Guid CartId { get; set; }
        public Hat Hat { get; set; }


        public int Quantity { get; set; }

       
    }
}
