using Mahtan.Data;
using Mahtan.Data.Repositories;
using Mahtan.Models;

namespace Mahtan.Data.Repositories
{
    public interface IProductSizeRepository : IRepository<ProductSize>
    {
    }

    public class ProductSizeRepository : Repository<ProductSize>, IProductSizeRepository
    {
        public ProductSizeRepository(ApplicationDbContext context) : base(context) { }

        public ApplicationDbContext DatabaseContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
