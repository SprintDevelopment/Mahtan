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

        [Display(Name = "عنوان اندازه")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(LengthConstants.MEDIUM_STRING, ErrorMessage = "حداکثر طول {0}، {1} کاراکتر است")]
        public string Title { get; set; }
        
        [Display(Name = "آیتم ها (با کاما جدا شوند)")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(LengthConstants.MEDIUM_STRING, ErrorMessage = "حداکثر طول {0}، {1} کاراکتر است")]
        public string ItemsString { get; set; }
        
        [Display(Name = "توضیحات اختیاری")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [MaxLength(LengthConstants.MEDIUM_STRING, ErrorMessage = "حداکثر طول {0}، {1} کاراکتر است")]
        public string Description { get; set; }
    }
}
