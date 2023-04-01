using HatShopWebAppWAzureDB.Classes;
using HatShopWebAppWAzureDB.Models.Domain;
using HatShopWebAppWAzureDB.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;

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

        public static string SortBy { get; set; }

        public static bool filterOn { get; set; }
        public static bool sortOn { get; set; }
        public static string currentSearch { get; set; }
        public async Task OnGet(string searchString, string sizeFilter, string colorFilter, string showInStock, string brandFilter, string sortBy, string clear, int pageIndex)
        {
            var pageSize = _configuration.GetValue("PageSize", 6);
            List<Hat> hats;
            var count = 0;
            if (searchString != null)
            {
                pageIndex = 1;
                currentSearch = searchString;
            }
            else {
            }

            if(!String.IsNullOrEmpty(sortBy))
            {
                SortBy = sortBy;
                sortOn = true;
            }

            
            if(!String.IsNullOrEmpty(sizeFilter) || !String.IsNullOrEmpty(colorFilter) || !String.IsNullOrEmpty(brandFilter) || ( !String.IsNullOrEmpty(showInStock) && !showInStock.Equals("false")))
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
                sortOn = false;
            }


            if (!String.IsNullOrEmpty(currentSearch) && String.IsNullOrEmpty(clear))
            {
                hats = await HatRepository.SearchByString(currentSearch);
                count = hats.Count();

            }
            else
            {
                if (!filterOn) { 
                    currentSearch = null;
                    count = await HatRepository.GetCountOfAllVisible();
                    hats = (List<Hat>) await HatRepository.GetAllAsync();
                }else
                {
                    hats = (List<Hat>)await HatRepository.FilterHats(SizeFilter, BrandFilter, ColorFilter, ShowInStock);
                    count = hats.Count();
                    
                }
            }

            if (sortOn && !String.IsNullOrEmpty(SortBy))
            {
                if (SortBy.Equals("newest"))
                {
                    hats=hats.OrderByDescending(h => h.PublishedDate).ToList();
                }
                if (SortBy.Equals("name"))
                {
                    hats=hats.OrderBy(h => h.Name).ToList();
                }
                if (SortBy.Equals("price"))
                {
                    hats=hats.OrderBy(h => h.Price).ToList();
                }
            }

            Hats = PaginatedList<Hat>.Create(hats, count, pageIndex == 0 ? 1 : pageIndex, pageSize);
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