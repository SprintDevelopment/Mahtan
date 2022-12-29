using Mahtan.Models;
using System;
using System.Threading.Tasks;

namespace Mahtan.Data.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationDbContext GetContext();

        IFaqRepository Faqs { get; }

        Task<int> CompleteAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Faqs = new FaqRepository(_context);
        }

        public IFaqRepository Faqs { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public ApplicationDbContext GetContext()
        {
            return _context;
        }
    }
}
