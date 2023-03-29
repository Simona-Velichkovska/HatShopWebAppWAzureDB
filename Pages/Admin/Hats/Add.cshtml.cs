using HatShopWebAppWAzureDB.Data;
using HatShopWebAppWAzureDB.Models.Domain;
using HatShopWebAppWAzureDB.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HatShopWebAppWAzureDB.Pages.Admin.Hats
{
    public class AddModel : PageModel
    {
        

        [BindProperty]
        public AddHat AddHatRequest { get; set; }

        //Constructor Injection of DbContext
        
        private readonly HatShopDbContext hatShopDbContext;
        public AddModel(HatShopDbContext hatShopDbContext)
        {
            this.hatShopDbContext = hatShopDbContext;
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            var hat = new Hat()
            {
                Name = AddHatRequest.Name,
                Description = AddHatRequest.Description,
                InStock = AddHatRequest.InStock,
                Color = AddHatRequest.Color,
                Size = AddHatRequest.Size,
                Brand = AddHatRequest.Brand,
                Quantity = AddHatRequest.Quantity,
                Price = AddHatRequest.Price,
                FeaturedImageUrl = AddHatRequest.FeaturedImageUrl,
                UrlHandle = AddHatRequest.UrlHandle,
                PublishedDate = DateTime.Now,
                Visible = AddHatRequest.Visible
            };
            hatShopDbContext.Hats.Add(hat);
            hatShopDbContext.SaveChanges();
        }
    }
}
