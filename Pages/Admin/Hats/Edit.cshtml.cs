using HatShopWebAppWAzureDB.Data;
using HatShopWebAppWAzureDB.Models.Domain;
using HatShopWebAppWAzureDB.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;

namespace HatShopWebAppWAzureDB.Pages.Admin.Hats
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Hat Hat { get; set; }

        private readonly IHatRepository HatRepository;

        public EditModel(IHatRepository HatRepository)
        {
            this.HatRepository = HatRepository;
        }

        public async Task OnGet(Guid id)
        {
            Hat = (Hat) await HatRepository.GetByIdAsync(id);
        }

        public async Task<IActionResult> OnPostEdit()
        {
            await HatRepository.UpdateAsync(Hat);

            return RedirectToPage("/Admin/Hats/List");
        }

        public async Task<IActionResult> OnPostDelete()
        {
            if (await HatRepository.DeleteAsync(Hat.Id))
            {
                return RedirectToPage("/Admin/Hats/List");
            }
            return Page();
        }

    }
}
