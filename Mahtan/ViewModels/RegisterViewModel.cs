using Mahtan.Assets.Values.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahtan.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "شماره همراه")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(LengthConstants.CALL_NUMBERS, ErrorMessage = "حداکثر طول {0}، {1} کاراکتر است")]
        public string PhoneNumber { get; set; }

        [Display(Name = "نام کامل")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(LengthConstants.LARGE_STRING, ErrorMessage = "حداکثر طول {0}، {1} کاراکتر است")]
        public string Name { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(LengthConstants.MEDIUM_STRING, ErrorMessage = "حداکثر طول {0}، {1} کاراکتر است")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "تکرار کلمه عبور")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(LengthConstants.MEDIUM_STRING, ErrorMessage = "حداکثر طول {0}، {1} کاراکتر است")]
        [DataType(DataType.Password)]
        [NotMapped]
        [Compare(nameof(Password), ErrorMessage = "کلمه عبور و تکرار آن با هم یکی نیستند")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }
}
