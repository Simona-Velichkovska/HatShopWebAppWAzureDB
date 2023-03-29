using HatShopWebAppWAzureDB.Data;
using HatShopWebAppWAzureDB.Models.Domain;
using HatShopWebAppWAzureDB.Models.ViewModels;
using HatShopWebAppWAzureDB.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HatShopWebAppWAzureDB.Pages.Admin.Hats
{
    public class AddModel : PageModel
    {
        

        [BindProperty]
        public AddHat AddHatRequest { get; set; }

        private readonly IHatRepository HatRepository;

        public AddModel(IHatRepository HatRepository)
        {
            this.HatRepository = HatRepository;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
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
            await HatRepository.AddAsync(hat);

            return RedirectToPage("/Admin/Hats/List");
        }
    }
}
