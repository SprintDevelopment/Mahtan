using Mahtan.Data;
using Mahtan.Data.Repositories;
using Mahtan.Models;

namespace Mahtan.Data.Repositories
{
    public interface IProfileRepository : IRepository<Profile>
    {
    }

    public class ProfileRepository : Repository<Profile>, IProfileRepository
    {
        public ProfileRepository(ApplicationDbContext context) : base(context) { }

        public ApplicationDbContext DatabaseContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
