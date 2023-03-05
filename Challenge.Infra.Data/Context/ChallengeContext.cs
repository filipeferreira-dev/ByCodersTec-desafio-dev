using Microsoft.EntityFrameworkCore;

namespace Challenge.Infra.Data.Context
{
    public class ChallengeContext : DbContext
    {
        public ChallengeContext(DbContextOptions<ChallengeContext> dbContextOptions) : base(dbContextOptions)
        {
            Database.Migrate();
        }
    }
}
