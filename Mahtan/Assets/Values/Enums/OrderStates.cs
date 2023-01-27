using System.ComponentModel.DataAnnotations;

namespace Mahtan.Assets.Values.Enums
{
    public enum OrderStates
    {
        [Display(Name = "ثبت شده")]
        Registered,
        [Display(Name = "تایید شده")]
        Confirmed,
        [Display(Name = "در حال پردازش")]
        InProgress,
        [Display(Name = "ارسال شده")]
        Sent,
        [Display(Name = "تحویل داده شده")]
        Delivered,
        [Display(Name = "مرجوع شده")]
        Rejected
    }
}
