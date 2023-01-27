using Mahtan.Models;

namespace Mahtan.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public ProductSearchViewModel SearchViewModel { get; set; }
    }
}
