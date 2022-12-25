using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mahtan.Assets.Values.Enums
{
    public enum FaqGroups
    {
        [Display(Name = "سفارش و خرید")]
        Order,
        [Display(Name = "بسته بندی و سفارش")]
        Shipping,
        [Display(Name = "پرداخت")]
        Payment,
        [Display(Name = "برگشت از خرید")]
        Return
    }
}
