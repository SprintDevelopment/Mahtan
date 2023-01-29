using Mahtan.Data;
using Mahtan.Data.Repositories;
using Mahtan.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Mahtan.Data.Repositories
{
    public interface IContentTemplateRepository : IRepository<ContentTemplate>
    {
    }

    public class ContentTemplateRepository : Repository<ContentTemplate>, IContentTemplateRepository
    {
        public ContentTemplateRepository(ApplicationDbContext context) : base(context) { }

        public ApplicationDbContext DatabaseContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
