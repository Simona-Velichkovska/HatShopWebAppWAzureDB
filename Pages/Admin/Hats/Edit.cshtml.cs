using HatShopWebAppWAzureDB.Data;
using HatShopWebAppWAzureDB.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;

namespace HatShopWebAppWAzureDB.Pages.Admin.Hats
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Hat Hat { get; set; }

        //Constuctor Injection of DB
        private readonly HatShopDbContext hatShopDbContext;
        public EditModel(HatShopDbContext hatShopDbContext)
        {
            this.hatShopDbContext = hatShopDbContext;
        }
        public void OnGet(Guid id)
        {
            Hat = hatShopDbContext.Hats.Find(id);
        }

        public IActionResult OnPostEdit()
        {
            var newHat = hatShopDbContext.Hats.Find(Hat.Id);
            if (newHat != null)
            {
                newHat.Name = Hat.Name;
                newHat.Description = Hat.Description;
                newHat.InStock = Hat.InStock;
                newHat.Color = Hat.Color;
                newHat.Size = Hat.Size;
                newHat.Brand = Hat.Brand;
                newHat.Quantity = Hat.Quantity;
                newHat.Price = Hat.Price;
                newHat.FeaturedImageUrl = Hat.FeaturedImageUrl;
                newHat.UrlHandle = Hat.UrlHandle;
                newHat.PublishedDate = DateTime.Now;
                newHat.Visible = Hat.Visible;
            }

            hatShopDbContext.SaveChanges();

            return RedirectToPage("/Admin/Hats/List");
        }

        public IActionResult OnPostDelete()
        {
            var currHat = hatShopDbContext.Hats.Find(Hat.Id);
            if (currHat != null)
            {
                hatShopDbContext.Hats.Remove(currHat);
            }

            hatShopDbContext.SaveChanges();

            return RedirectToPage("/Admin/Hats/List");
        }

    }
}
