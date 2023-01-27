using Mahtan.Data;
using Mahtan.Data.Repositories;
using Mahtan.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Mahtan.Data.Repositories
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
    }

    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(ApplicationDbContext context) : base(context) { }

        public ApplicationDbContext DatabaseContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
