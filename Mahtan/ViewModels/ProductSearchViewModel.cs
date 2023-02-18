using Mahtan.Assets.Values.Enums;
using Mahtan.Models;

namespace Mahtan.ViewModels
{
    public class ProductSearchViewModel
    {
        public Brand[] Brands { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        public SortOrders SortOrder { get; set; }

        public short SelectedCategoryId { get; set; }

        public long MinimumPrice { get; set; }
        public long MaximumPrice { get; set; }
    }
}
