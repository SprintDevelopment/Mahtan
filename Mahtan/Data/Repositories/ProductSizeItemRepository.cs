using Mahtan.Data;
using Mahtan.Data.Repositories;
using Mahtan.Models;

namespace Mahtan.Data.Repositories
{
    public interface IProductSizeItemRepository : IRepository<ProductSizeItem>
    {
    }

    public class ProductSizeItemRepository : Repository<ProductSizeItem>, IProductSizeItemRepository
    {
        public ProductSizeItemRepository(ApplicationDbContext context) : base(context) { }

        public ApplicationDbContext DatabaseContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
