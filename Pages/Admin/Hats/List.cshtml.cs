using HatShopWebAppWAzureDB.Data;
using HatShopWebAppWAzureDB.Models.Domain;
using HatShopWebAppWAzureDB.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HatShopWebAppWAzureDB.Pages.Admin.Hats
{
    public class ListModel : PageModel
    {

        public List<Hat> Hats { get; set; }

        private readonly IHatRepository HatRepository;

        public ListModel(IHatRepository HatRepository)
        {
            this.HatRepository = HatRepository;
        }
        public async Task OnGet()
        {
            Hats = (List<Hat>) await HatRepository.GetAllAsync();
        }
        public async Task<IActionResult> OnGetDelete(Guid id)
        {
           
           if (await HatRepository.DeleteAsync(id))
            {
                return RedirectToPage("/Admin/Hats/List");
            }

            return Page();
            
        }
    }
}
