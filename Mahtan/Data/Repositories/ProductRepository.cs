using Mahtan.Data;
using Mahtan.Data.Repositories;
using Mahtan.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Mahtan.Data.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IQueryable<Product> FindWithFirstImages(Expression<Func<Product, bool>> predicate = null);
    }

    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context) { }

        public ApplicationDbContext DatabaseContext
        {
            get { return Context as ApplicationDbContext; }
        }

        public IQueryable<Product> FindWithFirstImages(Expression<Func<Product, bool>> predicate = null) 
        {
            return DatabaseContext.Products.Where(predicate ?? (x => true)).Include(p => p.Images.Take(1));
        }
    }
}
