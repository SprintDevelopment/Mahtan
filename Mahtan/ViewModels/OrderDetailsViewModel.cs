using Mahtan.Models;

namespace Mahtan.ViewModels
{
    public class OrderDetailsViewModel
    {
        public Order Order { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }
    }
}
