using Challenge.Domain.Models;
using Challenge.Domain.Repositories;
using Challenge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Infra.Data.Repositories
{
    public class MerchantRepository : IMerchantRepository
    {
        ChallengeContext Context { get; }

        public MerchantRepository(ChallengeContext context)
        {
            Context = context;
        }

        public async Task<IEnumerable<Merchant>> GetAllAsync()
        => await Context.Set<Merchant>().Include(m => m.Transactions).ToListAsync();

        public async Task AddRangeAsync(IEnumerable<Merchant> entities)
        {
            foreach (var entity in entities)
                await Context.AddAsync(entity);

            await Context.SaveChangesAsync();
        }
    }
}
