using HatShopWebAppWAzureDB.Data;
using HatShopWebAppWAzureDB.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HatShopWebAppWAzureDB.Pages.Admin.Hats
{
    public class ListModel : PageModel
    {

        public List<Hat> Hats { get; set; }

        //Constructor Injection of DB
        private readonly HatShopDbContext hatShopDbContext;

        public ListModel(HatShopDbContext hatShopDbContext)
        {
            this.hatShopDbContext = hatShopDbContext;
        }
        public void OnGet()
        {
            Hats = hatShopDbContext.Hats.ToList();
        }
    }
}
