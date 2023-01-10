using Mahtan.Data;
using Mahtan.Data.Repositories;
using Mahtan.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Mahtan.Data.Repositories
{
    public interface IProductReviewRepository : IRepository<ProductReview>
    {
    }

    public class ProductReviewRepository : Repository<ProductReview>, IProductReviewRepository
    {
        public ProductReviewRepository(ApplicationDbContext context) : base(context) { }

        public ApplicationDbContext DatabaseContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
