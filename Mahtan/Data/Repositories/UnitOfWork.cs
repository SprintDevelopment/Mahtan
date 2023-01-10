using Mahtan.Models;
using System;
using System.Threading.Tasks;

namespace Mahtan.Data.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationDbContext GetContext();

        IAddressRepository Addresses { get; }
        IBannerRepository Banners { get; }
        ICategoryRepository Categories { get; }
        IDistrictRepository Districts { get; }
        IFaqRepository Faqs { get; }
        IProductRepository Products { get; }
        IProductImageRepository ProductImages { get; }
        IProductReviewRepository ProductReviews { get; }
        IProfileRepository Profiles { get; }

        Task<int> CompleteAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Addresses = new AddressRepository(_context);
            Banners = new BannerRepository(_context);
            Categories = new CategoryRepository(_context);
            Districts = new DistrictRepository(_context);
            Faqs = new FaqRepository(_context);
            Products = new ProductRepository(_context);
            ProductImages = new ProductImageRepository(_context);
            ProductReviews = new ProductReviewRepository(_context);
            Profiles = new ProfileRepository(_context);
        }

        public IAddressRepository Addresses { get; private set; }
        public IBannerRepository Banners { get; private set; }
        public ICategoryRepository Categories { get; private set; }
        public IDistrictRepository Districts { get; private set; }
        public IFaqRepository Faqs { get; private set; }
        public IProductRepository Products { get; private set; }
        public IProductImageRepository ProductImages { get; private set; }
        public IProductReviewRepository ProductReviews { get; private set; }
        public IProfileRepository Profiles { get; private set; }

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
