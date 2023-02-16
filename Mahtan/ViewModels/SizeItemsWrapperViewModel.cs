using Mahtan.Models;

namespace Mahtan.ViewModels
{
    public class SizeItemsWrapperViewModel
    {
        public bool UseForOneSizeSelection { get; set; }
        public FakeNamespace.Product Product { get; set; }
    }
}

namespace Mahtan.FakeNamespace
{
    public class Product
    {
        public ProductSizeItem[] CategorySizeItems { get; set; }
        public ProductSizeItem[] ProductSizeItems { get; set; }

        public short SelectedSize { get; set; }
    }
}