using System.ComponentModel.DataAnnotations;

namespace Mahtan.ViewModels
{
    public class ConfirmPhoneViewModel
    {
        [Display(Name = "شماره همراه")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string PhoneNumber { get; set; }

        [Display(Name = "کد فعالسازی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string VerificationCode { get; set; }
    }
}
