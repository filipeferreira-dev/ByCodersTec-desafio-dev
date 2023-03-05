using Challenge.Domain.Models;

namespace Challenge.Domain.Repositories
{
    public interface IMerchantRepository
    {
        Task AddRangeAsync(IEnumerable<Merchant> entities);

        Task<IEnumerable<Merchant>> GetAllAsync();
    }
}
