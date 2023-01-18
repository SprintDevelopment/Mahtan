using System.ComponentModel.DataAnnotations;

namespace Mahtan.Assets.Values.Enums
{
    public enum FaqGroups
    {
        [Display(Name = "سفارش و خرید")]
        Order,
        [Display(Name = "بسته بندی و ارسال")]
        Shipping,
        [Display(Name = "پرداخت")]
        Payment,
        [Display(Name = "برگشت از خرید")]
        Return
    }
}
