using Mahtan.Models;

namespace Mahtan.ViewModels
{
    public class HeaderViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<CartItem> CartItems { get; set; }
    }
}
