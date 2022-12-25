using Mahtan.Models;

namespace Mahtan.Data.Repositories
{
    public interface IFaqRepository : IRepository<Faq>
    {
    }

    public class FaqRepository : Repository<Faq>, IFaqRepository
    {
        public FaqRepository(ApplicationDbContext context) : base(context) { }

        public ApplicationDbContext DatabaseContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
