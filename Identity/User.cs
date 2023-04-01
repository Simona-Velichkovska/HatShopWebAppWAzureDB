using Microsoft.AspNetCore.Identity;

namespace HatShopWebAppWAzureDB.Identity
{
    public class User: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
