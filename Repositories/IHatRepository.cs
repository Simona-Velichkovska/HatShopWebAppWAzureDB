using HatShopWebAppWAzureDB.Models.Domain;

namespace HatShopWebAppWAzureDB.Repositories
{
    public interface IHatRepository
    {
        Task<IEnumerable<Hat>> GetAllAsync();

        Task<Int32> GetCountOfAllVisible();

        Task<List<Hat>> TakeSomeAsync(int skip, int size);
        Task<Hat> GetByIdAsync(Guid id);

        Task<Hat> AddAsync(Hat hat);

        Task<Hat> UpdateAsync(Hat hat);
        Task<bool> DeleteAsync(Guid id);


        Task<List<Hat>> SearchByString(string search);

        Task<List<Hat>> FilterHats(List<Hat> hats,string size, string brand, string color, string stock);

    }
}
