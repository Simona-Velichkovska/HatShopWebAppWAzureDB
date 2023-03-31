using HatShopWebAppWAzureDB.Classes;
using HatShopWebAppWAzureDB.Models.Domain;
using HatShopWebAppWAzureDB.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace HatShopWebAppWAzureDB.Pages
{
    public class IndexModel : PageModel
    {
        public PaginatedList<Hat> Hats { get; set; }

        private readonly IHatRepository HatRepository;
        private readonly IConfiguration _configuration;



        public IndexModel(IHatRepository HatRepository, IConfiguration configuration)
        {
            this.HatRepository = HatRepository;
            _configuration = configuration;
        }

        public static string currentSearch { get; set; }
        public async Task OnGet(string searchString,string clear, int pageIndex)
        {
            var pageSize = _configuration.GetValue("PageSize", 6);

            if (searchString != null)
            {
                pageIndex = 1;
                currentSearch = searchString;
            }
            else {
            }
            

            if (!String.IsNullOrEmpty(currentSearch) && String.IsNullOrEmpty(clear))
            {
                List<Hat> hats = await HatRepository.SearchByString(currentSearch);
                var cnt = hats.Count();
                Hats = PaginatedList<Hat>.Create(hats, cnt, pageIndex == 0 ? 1 : pageIndex, pageSize);

            }
            else
            {
                currentSearch = null;
                var count = await HatRepository.GetCountOfAllVisible();
                List<Hat> items = (List<Hat>) await HatRepository.GetAllAsync();
                Hats = PaginatedList<Hat>.Create(items,count, pageIndex==0?1:pageIndex, pageSize);
            }
            
        }

    }
}