using Mahtan.Models;

namespace Mahtan.ViewModels
{
    public class MainPageViewModel
    {
        public IEnumerable<Banner> Banners { get; set; }
        public IEnumerable<Product> PopularProducts { get; set; }
    }
}
