using Mahtan.Data;
using Mahtan.Data.Repositories;
using Mahtan.Models;

namespace Mahtan.Data.Repositories
{
    public interface IBannerRepository : IRepository<Banner>
    {
    }

    public class BannerRepository : Repository<Banner>, IBannerRepository
    {
        public BannerRepository(ApplicationDbContext context) : base(context) { }

        public ApplicationDbContext DatabaseContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
