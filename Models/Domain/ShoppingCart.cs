namespace HatShopWebAppWAzureDB.Models.Domain
{
    public class ShoppingCart
    {
        private Guid id { get; set; }
        private DateTime dateCreated { get; set; }
        //private User user;
        private List<Hat> hatList { get; set; }
       
    }
}
