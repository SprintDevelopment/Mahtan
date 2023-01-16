using Mahtan.Assets.Values;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahtan.Models
{
    public class ProductImage : BaseModel
    {
        [Key]
        public long ProductImageId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Display(Name = "فایل تصویر")]
        [Required(AllowEmptyStrings = true)]
        public string ImageGuid { get; set; }

        [NotMapped]
        public string ImageLargeFullPath => string.Format("/{0}/{1}", Addresses.ProductLargeImagesPath.Replace('\\', '/'), ImageGuid ?? "no-image.png");

        [NotMapped]
        public string ImageThumbFullPath => string.Format("/{0}/{1}", Addresses.ProductThumbImagesPath.Replace('\\', '/'), ImageGuid ?? "no-image.png");

        [Required(AllowEmptyStrings = true)]
        public string OptionalComment { get; set; }
    }
}
