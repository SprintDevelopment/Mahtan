using Mahtan.Data;
using Mahtan.Data.Repositories;
using Mahtan.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Mahtan.Data.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
    }

    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context) { }

        public ApplicationDbContext DatabaseContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
