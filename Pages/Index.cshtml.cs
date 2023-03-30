using HatShopWebAppWAzureDB.Classes;
using HatShopWebAppWAzureDB.Models.Domain;
using HatShopWebAppWAzureDB.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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

        public async Task OnGetAsync(string searchString,int pageIndex=1)
        {
            var pageSize = _configuration.GetValue("PageSize", 6);
            var skip = Math.Abs((pageIndex - 1) * pageSize);
            if(!String.IsNullOrEmpty(searchString))
            {
                
                List<Hat> hats = await HatRepository.SearchByString(searchString);
                var cnt = hats.Count();
                Hats = await PaginatedList<Hat>.CreateAsync(hats, cnt, pageIndex < 0 ? 1 : pageIndex, pageSize);

            }
            else
            {
                var count = await HatRepository.GetCountOfAllVisible();
            
                List<Hat> items = await HatRepository.TakeSomeAsync(skip,pageSize);
                Hats = await PaginatedList<Hat>.CreateAsync(items,count, pageIndex<0?1:pageIndex, pageSize);
            }
            
        }


    }
}