using System.ComponentModel.DataAnnotations;

namespace Mahtan.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Display(Name = "شماره همراه")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [RegularExpression(@"^09\d{2}\s?\d{3}\s?\d{4}$", ErrorMessage = "{0} با فرمت اشتباه وارد شده است")] 
        public string PhoneNumber { get; set; }
    }
}
