using Mahtan.Assets.Attributes;
using Mahtan.Assets.Values;
using Mahtan.Assets.Values.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahtan.Models
{
    [Model(SingleEntityTitle = "برند محصول", MultipleEntitiesTitle = "برندهای محصول")]
    public class Brand : BaseModel
    {
        [Key]
        public short BrandId { get; set; }

        [Display(Name = "عنوان برند")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(LengthConstants.MEDIUM_STRING, ErrorMessage = "حداکثر طول {0}، {1} کاراکتر است")]
        public string Title { get; set; }

        [Display(Name = "لوگوی برند")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string LogoGuid { get; set; }

        [NotMapped]
        public string LogoFullPath => string.Format("~/{0}/{1}", Addresses.BrandLogosPath.Replace('\\', '/'), LogoGuid ?? "no-image.png");

        [Display(Name = "توضیحات اختیاری")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [MaxLength(LengthConstants.VERY_LARGE_STRING, ErrorMessage = "حداکثر طول {0}، {1} کاراکتر است")]
        public string OptionalComment { get; set; } = "";

        public Brand()
        {
        }
    }
}
