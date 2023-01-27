using Mahtan.Assets.Attributes;
using Mahtan.Assets.Values.Constants;
using System.ComponentModel.DataAnnotations;

namespace Mahtan.Models
{
    [Model(SingleEntityTitle = "روش ارسال", MultipleEntitiesTitle = "روش های ارسال")]
    public class ShippingType : BaseModel
    {
        [Key]
        public short ShippingTypeId { get; set; }

        [Display(Name = "عنوان روش")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(LengthConstants.MEDIUM_STRING, ErrorMessage = "حداکثر طول {0}، {1} کاراکتر است")]
        public string Title { get; set; }

        [Display(Name = "بازه تحویل")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(LengthConstants.MEDIUM_STRING, ErrorMessage = "حداکثر طول {0}، {1} کاراکتر است")]
        public string DeliveryRange { get; set; }

        [Display(Name = "هزینه ارسال")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [Range(0, int.MaxValue, ErrorMessage = "{0} باید عددی بین  {1} و {2} باشد")]
        public long Cost { get; set; }

        [Display(Name = "توضیحات اختیاری")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [MaxLength(LengthConstants.MEDIUM_STRING, ErrorMessage = "حداکثر طول {0}، {1} کاراکتر است")]
        public string OptionalComment { get; set; } = "";

        [Display(Name = "ردیف نمایش")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public int DisplayOrder { get; set; }
    }
}
