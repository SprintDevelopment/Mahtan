using System.ComponentModel.DataAnnotations;

namespace Mahtan.ViewModels
{
    public class ConfirmPhoneViewModel
    {
        [Display(Name = "شماره همراه")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} را وارد کنید")]
        public string PhoneNumber { get; set; }

        [Display(Name = "کد فعالسازی")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} را وارد کنید")]
        public int VerificationCode { get; set; }
    }
}
