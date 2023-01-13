using Mahtan.Data;
using Mahtan.Data.Repositories;
using Mahtan.Models;

namespace Mahtan.Data.Repositories
{
    public interface IBrandRepository : IRepository<Brand>
    {
    }

    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(ApplicationDbContext context) : base(context) { }

        public ApplicationDbContext DatabaseContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
