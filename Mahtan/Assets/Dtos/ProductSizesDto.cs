using Mahtan.Assets.Values.Constants;
using Mahtan.Models;
using System.ComponentModel.DataAnnotations;

namespace Mahtan.Assets.Dtos
{
    public class ProductSizesDto
    {
        public short ProductSizeId { get; set; }

        public string Title { get; set; }

        public IEnumerable<ProductSizeItem> Items { get; set; }

        public string ItemsString { get; set; }
    }

    public class ProductSizeItem
    {
        public short ProductSizeItemId { get; set; }
        public string Title { get; set; }
        public short DisplayOrder { get; set; }
    }
}
