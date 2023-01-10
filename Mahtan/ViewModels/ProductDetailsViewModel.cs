using Mahtan.Models;

namespace Mahtan.ViewModels
{
    public class ProductDetailsViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<Product> SimilarProducts { get; set; }
        public IEnumerable<ProductReview> Reviews { get; set; }

    }
}
