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
        IBrandRepository Brands { get; }
        ICategoryRepository Categories { get; }
        ICartItemRepository CartItems { get; }
        IContentTemplateRepository ContentTemplates { get; }
        IDistrictRepository Districts { get; }
        IFaqRepository Faqs { get; }
        IOrderItemRepository OrderItems { get; }
        IOrderRepository Orders { get; }
        IProductRepository Products { get; }
        IProductImageRepository ProductImages { get; }
        IProductReviewRepository ProductReviews { get; }
        IProductSizeItemRepository ProductSizeItems { get; }
        IProductSizeRepository ProductSizes { get; }
        IProfileRepository Profiles { get; }
        IShippingTypeRepository ShippingTypes { get; }

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
            Brands = new BrandRepository(_context);
            Categories = new CategoryRepository(_context);
            CartItems = new CartItemRepository(_context);
            ContentTemplates = new ContentTemplateRepository(_context);
            Districts = new DistrictRepository(_context);
            Faqs = new FaqRepository(_context);
            OrderItems = new OrderItemRepository(_context);
            Orders = new OrderRepository(_context);
            Products = new ProductRepository(_context);
            ProductImages = new ProductImageRepository(_context);
            ProductReviews = new ProductReviewRepository(_context);
            ProductSizeItems = new ProductSizeItemRepository(_context);
            ProductSizes = new ProductSizeRepository(_context);
            Profiles = new ProfileRepository(_context);
            ShippingTypes = new ShippingTypeRepository(_context);
        }

        public IAddressRepository Addresses { get; private set; }
        public IBannerRepository Banners { get; private set; }
        public IBrandRepository Brands { get; private set; }
        public ICategoryRepository Categories { get; private set; }
        public ICartItemRepository CartItems { get; private set; }
        public IContentTemplateRepository ContentTemplates { get; private set; }
        public IDistrictRepository Districts { get; private set; }
        public IFaqRepository Faqs { get; private set; }
        public IOrderItemRepository OrderItems { get; private set; }
        public IOrderRepository Orders { get; private set; }
        public IProductRepository Products { get; private set; }
        public IProductImageRepository ProductImages { get; private set; }
        public IProductReviewRepository ProductReviews { get; private set; }
        public IProductSizeItemRepository ProductSizeItems { get; private set; }
        public IProductSizeRepository ProductSizes { get; private set; }
        public IProfileRepository Profiles { get; private set; }
        public IShippingTypeRepository ShippingTypes { get; private set; }

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
