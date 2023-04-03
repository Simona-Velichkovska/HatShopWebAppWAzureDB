using HatShopWebAppWAzureDB.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HatShopWebAppWAzureDB.Models.Domain
{
    public class ShoppingCart 
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public User User { get; set; }
        public CartItems CartItems { get; set; }

    }
}
