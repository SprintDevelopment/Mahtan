using System.ComponentModel.DataAnnotations;

namespace Mahtan.Assets.Values.Enums
{
    public enum ReviewCheckStates
    {
        [Display(Name = "بررسی نشده")]
        NotChecked,
        [Display(Name = "تایید شده")]
        Accepted,
        [Display(Name = "رد شده")]
        Rejected,
    }
}
