using Mahtan.Data;
using Mahtan.Data.Repositories;
using Mahtan.Models;

namespace Mahtan.Data.Repositories
{
    public interface IShippingTypeRepository : IRepository<ShippingType>
    {
    }

    public class ShippingTypeRepository : Repository<ShippingType>, IShippingTypeRepository
    {
        public ShippingTypeRepository(ApplicationDbContext context) : base(context) { }

        public ApplicationDbContext DatabaseContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
