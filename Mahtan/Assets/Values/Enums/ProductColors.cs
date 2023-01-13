using System.ComponentModel.DataAnnotations;

namespace Mahtan.Assets.Values.Enums
{
    public enum ProductColors
    {
        [Display(Name = "مشخص نشده")]
        None = 0,
        [Display(Name = "سفید")]
        White = 1,
        [Display(Name = "مشکی")]
        Black = 2,
        [Display(Name = "قرمز")]
        Red = 4,
        [Display(Name = "سبز")]
        Green = 8,
        [Display(Name = "آبی")]
        Blue = 16,
        [Display(Name = "زرد")]
        Yellow = 32,
        [Display(Name = "صورتی")]
        Pink = 64,
        [Display(Name = "قهوه ای")]
        Brown = 128
    }
}
