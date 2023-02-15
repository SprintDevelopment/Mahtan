using Mahtan.Models;
using System.Drawing;

namespace Mahtan.ViewModels
{
    public class MainPageViewModel
    {
        public IEnumerable<Banner> Banners { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<Product> PopularProducts { get; set; }
    }
}
