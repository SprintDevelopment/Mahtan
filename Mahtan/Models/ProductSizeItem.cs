using Mahtan.Assets.Values.Constants;
using Mahtan.Assets.Values.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahtan.Models
{
    public class ProductSizeItem : BaseModel
    {
        [Key]
        public short ProductSizeItemId { get; set; }

        [Display(Name = "اندازه محصول")]
        [Required(ErrorMessage = "{0} را انتخاب کنید")]
        public short ProductSizeId { get; set; }

        [Display(Name = "عنوان آیتم")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(LengthConstants.MEDIUM_STRING, ErrorMessage = "حداکثر طول {0}، {1} کاراکتر است")]
        public string Title { get; set; }

        [Display(Name = "ردیف نمایش")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public short DisplayOrder { get; set; }
    }
}
