using Mahtan.Assets.Attributes;
using Mahtan.Assets.Values;
using Mahtan.Assets.Values.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahtan.Models
{
    [Model(SingleEntityTitle = "بنر", MultipleEntitiesTitle = "بنرها")]
    public class Banner : BaseModel
    {
        [Key]
        public short BannerId { get; set; }

        [Display(Name = "فایل تصویر بنر")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string BannerGuid { get; set; }

        [NotMapped]
        public string BannerFullPath => string.Format("/{0}/{1}", Addresses.BannerImagesPath.Replace('\\', '/'), BannerGuid ?? "no-image.png");

        [Display(Name = "متن اولیه")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(LengthConstants.MEDIUM_STRING, ErrorMessage = "حداکثر طول {0}، {1} کاراکتر است")]
        public string PreText { get; set; }

        [Display(Name = "متن اصلی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(LengthConstants.MEDIUM_STRING, ErrorMessage = "حداکثر طول {0}، {1} کاراکتر است")]
        public string MainText { get; set; }

        [Display(Name = "متن توضیح")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(LengthConstants.LARGE_STRING, ErrorMessage = "حداکثر طول {0}، {1} کاراکتر است")]
        public string DescriptionText { get; set; }

        [Display(Name = "محتوای لینک")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(LengthConstants.MEDIUM_STRING, ErrorMessage = "حداکثر طول {0}، {1} کاراکتر است")]
        public string LinkContent { get; set; }

        [Display(Name = "آدرس لینک")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(LengthConstants.LARGE_STRING, ErrorMessage = "حداکثر طول {0}، {1} کاراکتر است")]
        public string LinkAddress { get; set; }

        [Display(Name = "رنگ پس زمینه اختیاری")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string BackColor { get; set; } = "#FFF";

        [Display(Name = "برای نمایش در صفحه اصلی فعال باشد.")]
        public bool IsActive { get; set; } = true;
    }
}
