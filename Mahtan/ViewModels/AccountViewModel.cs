using Mahtan.Models;

namespace Mahtan.ViewModels
{
    public class AccountViewModel
    {
        public LoginViewModel LoginViewModel { get; set; }
        public RegisterViewModel RegisterViewModel { get; set; }
        public ForgotPasswordViewModel ForgotPasswordViewModel { get; set; }
    }
}
