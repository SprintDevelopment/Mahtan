using Mahtan.Data;
using Mahtan.Data.Repositories;
using Mahtan.Models;

namespace Mahtan.Data.Repositories
{
    public interface ICartItemRepository : IRepository<CartItem>
    {
    }

    public class CartItemRepository : Repository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(ApplicationDbContext context) : base(context) { }

        public ApplicationDbContext DatabaseContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
