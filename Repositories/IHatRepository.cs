using HatShopWebAppWAzureDB.Models.Domain;

namespace HatShopWebAppWAzureDB.Repositories
{
    public interface IHatRepository
    {
        Task<IEnumerable<Hat>> GetAllAsync();
        Task<Hat> GetByIdAsync(Guid id);

        Task<Hat> AddAsync(Hat hat);

        Task<Hat> UpdateAsync(Hat hat);
        Task<bool> DeleteAsync(Guid id);

    }
}
