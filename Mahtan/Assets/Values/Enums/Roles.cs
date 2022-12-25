using System.ComponentModel.DataAnnotations;

namespace Mahtan.Assets.Values.Enums
{
    public enum Roles
    {
        [Display(Name = "مدیر")]
        Admin,
        [Display(Name = "کاربر")]
        User,
        [Display(Name = "شبه مدیر")]
        SemiAdmin
    }
}
