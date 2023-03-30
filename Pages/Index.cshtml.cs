using HatShopWebAppWAzureDB.Models.Domain;
using HatShopWebAppWAzureDB.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HatShopWebAppWAzureDB.Pages
{
    public class IndexModel : PageModel
    {
        public List<Hat> Hats { get; set; }

        private readonly IHatRepository HatRepository;

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, IHatRepository HatRepository)
        {
            _logger = logger;
            this.HatRepository = HatRepository;
        }

        public async Task OnGet()
        {
            Hats = (List<Hat>)await HatRepository.GetAllAsync();
        }
    }
}