﻿namespace HatShopWebAppWAzureDB.Models.ViewModels
{
    public class AddHat
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool InStock { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string FeaturedImageUrl { get; set; }
        public string UrlHandle { get; set; }
        public bool Visible { get; set; }
    }
}
