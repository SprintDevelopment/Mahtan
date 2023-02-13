using Mahtan.Models;

namespace Mahtan.ViewModels
{
    public class SizeItemsWrapperViewModel
    {
        public FakeNamespace.Product Product { get; set; }
    }
}

namespace Mahtan.FakeNamespace
{
    public class Product
    {
        public ProductSizeItem[] SizeItems { get; set; }
    }
}