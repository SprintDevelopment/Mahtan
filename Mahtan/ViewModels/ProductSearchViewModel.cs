using Mahtan.Assets.Values.Enums;
using Mahtan.Models;

namespace Mahtan.ViewModels
{
    public class ProductSearchViewModel
    {
        public IEnumerable<SelectableBrand> Brands { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        public SortOrders SortOrder { get; set; }
    }

    public class SelectableBrand
    {
        public Brand Brand { get; set; }
        public bool IsSelected { get; set; }

        public SelectableBrand(Brand brand)
        {
            Brand = brand;
        }
    }
}
