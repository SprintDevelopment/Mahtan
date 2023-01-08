using Mahtan.Models;

namespace Mahtan.ViewModels
{
    public class SearchProductViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }

    }
}
