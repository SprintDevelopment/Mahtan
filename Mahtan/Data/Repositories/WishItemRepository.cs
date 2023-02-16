using Mahtan.Data;
using Mahtan.Data.Repositories;
using Mahtan.Models;

namespace Mahtan.Data.Repositories
{
    public interface IWishItemRepository : IRepository<WishItem>
    {
    }

    public class WishItemRepository : Repository<WishItem>, IWishItemRepository
    {
        public WishItemRepository(ApplicationDbContext context) : base(context) { }

        public ApplicationDbContext DatabaseContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
