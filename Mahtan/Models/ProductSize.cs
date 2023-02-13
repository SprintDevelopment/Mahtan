using Mahtan.Assets.Attributes;
using Mahtan.Assets.Values.Constants;
using System.ComponentModel.DataAnnotations;

namespace Mahtan.Models
{
    [Model(SingleEntityTitle = "اندازه محصول", MultipleEntitiesTitle = "اندازه های محصولات")]
    public class ProductSize : BaseModel
    {
        [Key]
        public short ProductSizeId { get; set; }

        public virtual ICollection<ProductSizeItem> SizeItems { get; set; }

        [Display(Name = "عنوان اندازه")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(LengthConstants.MEDIUM_STRING, ErrorMessage = "حداکثر طول {0}، {1} کاراکتر است")]
        public string Title { get; set; }
    }
}
