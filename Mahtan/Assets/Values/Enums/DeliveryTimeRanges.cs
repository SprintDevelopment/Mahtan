using System.ComponentModel.DataAnnotations;

namespace Mahtan.Assets.Values.Enums
{
    public enum DeliveryTimeRanges
    {
        [Display(Name = "ساعت 9 تا 12")]
        _9_12,
        [Display(Name = "ساعت 12 تا 15")]
        _12_15,
        [Display(Name = "ساعت 15 تا 18")]
        _15_18,
        [Display(Name = "ساعت 18 تا 21")]
        _18_21,
        [Display(Name = "ساعت 21 تا 24")]
        _21_24
    }
}
