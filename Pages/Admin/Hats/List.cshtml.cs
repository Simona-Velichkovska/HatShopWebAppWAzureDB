using HatShopWebAppWAzureDB.Data;
using HatShopWebAppWAzureDB.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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
        public async Task OnGet()
        {
            Hats = await hatShopDbContext.Hats.ToListAsync();
        }
        public async Task<IActionResult> OnGetDelete(Guid id)
        {
            var currHat = await hatShopDbContext.Hats.FindAsync(id);
            if (currHat != null)
            {
                hatShopDbContext.Hats.Remove(currHat);
                await hatShopDbContext.SaveChangesAsync();

                return RedirectToPage("/Admin/Hats/List");
            }

            return Page();
            
        }
    }
}
