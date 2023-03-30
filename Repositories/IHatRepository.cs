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

    }
}
