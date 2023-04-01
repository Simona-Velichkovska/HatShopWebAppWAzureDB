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

        public static string SizeFilter { get; set; }
        public static string ColorFilter { get; set; }
        public static string ShowInStock { get; set; }
        public static string BrandFilter { get; set; }

        public static bool filterOn { get; set; }

        public static string currentSearch { get; set; }
        public async Task OnGet(string searchString, string sizeFilter, string colorFilter, string showInStock, string brandFilter, string clear, int pageIndex)
        {
            var pageSize = _configuration.GetValue("PageSize", 6);

            if (searchString != null)
            {
                pageIndex = 1;
                currentSearch = searchString;
            }
            else {
            }
            
            if(!String.IsNullOrEmpty(sizeFilter) || !String.IsNullOrEmpty(colorFilter) || !String.IsNullOrEmpty(brandFilter) || ( !String.IsNullOrEmpty(showInStock) && showInStock.Equals("false")))
            {
                SizeFilter=sizeFilter;
                ColorFilter = colorFilter;
                BrandFilter = brandFilter;
                ShowInStock=showInStock;
                filterOn=true;
            }
            if (!String.IsNullOrEmpty(clear)&& clear.Equals("clear"))
            {
                filterOn = false;
            }


            if (!String.IsNullOrEmpty(currentSearch) && String.IsNullOrEmpty(clear))
            {
                List<Hat> hats = await HatRepository.SearchByString(currentSearch);
                var cnt = hats.Count();
                Hats = PaginatedList<Hat>.Create(hats, cnt, pageIndex == 0 ? 1 : pageIndex, pageSize);

            }
            else
            {
                if (!filterOn) { 
                currentSearch = null;
                var count = await HatRepository.GetCountOfAllVisible();
                List<Hat> items = (List<Hat>) await HatRepository.GetAllAsync();
                Hats = PaginatedList<Hat>.Create(items,count, pageIndex==0?1:pageIndex, pageSize);
                }else
                {
                    List<Hat> items = (List<Hat>)await HatRepository.FilterHats(SizeFilter, BrandFilter, ColorFilter, ShowInStock);
                    var count = items.Count();
                    Hats = PaginatedList<Hat>.Create(items, count, pageIndex == 0 ? 1 : pageIndex, pageSize);
                }
            }

            
            
        }
/*
        public async Task OnPostFilter(int pageIndex)
        {
            filterOn = true;
            var pageSize = _configuration.GetValue("PageSize", 6);

            List<Hat> items = (List<Hat>) await HatRepository.FilterHats(sizeFilter, brandFilter, colorFilter, showInStock);
            var count = items.Count();
            Hats = PaginatedList<Hat>.Create(items, count, pageIndex == 0 ? 1 : pageIndex, pageSize);
        }
*/
    }
}