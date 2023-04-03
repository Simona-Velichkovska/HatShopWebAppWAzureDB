using HatShopWebAppWAzureDB.Models.Domain;
using HatShopWebAppWAzureDB.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HatShopWebAppWAzureDB.Pages.User
{
    public class DetailsModel : PageModel
    {
        [BindProperty]
        public Hat Hat { get; set; }

        private readonly IHatRepository HatRepository;

        public DetailsModel(IHatRepository HatRepository)
        {
            this.HatRepository = HatRepository;
        }
        public async Task OnGet(Guid id)
        {
            Hat = (Hat)await HatRepository.GetByIdAsync(id);
        }
    }
}
