using Mahtan.Models;

namespace Mahtan.ViewModels
{
    public class ProductDetailsViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<Product> MyProperty { get; set; }
    }
}
