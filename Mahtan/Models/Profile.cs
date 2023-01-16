using Mahtan.Assets.Values;
using Mahtan.Assets.Values.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahtan.Models
{
    public class Profile : BaseModel
    {
        [Key]
        public string Username { get; set; }

        [Display(Name = "نام")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(LengthConstants.MEDIUM_STRING, ErrorMessage = "حداکثر طول {0}، {1} کاراکتر است")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(LengthConstants.MEDIUM_STRING, ErrorMessage = "حداکثر طول {0}، {1} کاراکتر است")]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName { get => $"{FirstName} {LastName}"; }

        [Display(Name = "ایمیل")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "{0} را به درستی وارد کنید")]
        [MaxLength(LengthConstants.MEDIUM_STRING, ErrorMessage = "حداکثر طول {0}، {1} کاراکتر است")]
        public string EmailAddress { get; set; }

        [Display(Name = "شماره تماس ضروری")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string UrgentPhoneNumber { get; set; } = "";

        [Display(Name = "تصویر پروفایل - اختیاری")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string OptionalAvatarGuid { get; set; }

        [NotMapped]
        public string AvatarFullPath => string.Format("/{0}/{1}", Addresses.UserAvatarImagesPath.Replace('\\', '/'), OptionalAvatarGuid ?? "no-image.png");

        [Display(Name = "پیشنهادهای شگفت انگیز به ایمیل شما ارسال شود ؟")]
        public bool RecieveOffersByEmail { get; set; }

        [Display(Name = "پیشنهادهای شگفت انگیز به شماره شما ارسال شود ؟")]
        public bool RecieveOffersByShortMessage { get; set; }
    }
}
