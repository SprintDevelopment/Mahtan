using Mahtan.Assets.Attributes;
using Mahtan.Assets.Values.Constants;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mahtan.Models
{
    [Model(SingleEntityTitle = "آدرس", MultipleEntitiesTitle = "آدرس ها")]
    public class Address : BaseModel
    {
        [Key]
        public int AddressId { get; set; }

        [Required]
        public string Username { get; set; }

        [Display(Name = "عنوان آدرس")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(LengthConstants.MEDIUM_STRING, ErrorMessage = "حداکثر طول {0}، {1} کاراکتر است")]
        public string Title { get; set; }

        [Display(Name = "محله مورد نظر")]
        [Required(ErrorMessage = "{0} را انتخاب کنید")]
        public short DistrictId { get; set; }

        [ForeignKey(nameof(DistrictId))]
        public District District { get; set; }

        [Display(Name = "ادامه آدرس")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(LengthConstants.LARGE_STRING, ErrorMessage = "حداکثر طول {0}، {1} کاراکتر است")]
        public string EndPart { get; set; }

        [Display(Name = "کد پستی")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "{0} را به درستی وارد کنید")]
        [MaxLength(LengthConstants.POSTAL_CODES, ErrorMessage = "حداکثر طول {0}، {1} کاراکتر است")]
        public string PostalCode { get; set; } = "";

        [Display(Name = "به عنوان آدرس پیشفرض در نظر گرفته شود ؟")]
        public bool IsSelectedAddress { get; set; }
    }
}
