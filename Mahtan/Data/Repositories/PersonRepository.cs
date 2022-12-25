using Mahtan.Models;

namespace Mahtan.Data.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
    }

    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(ApplicationDbContext context) : base(context) { }

        public ApplicationDbContext DatabaseContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
