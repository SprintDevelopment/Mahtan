using System.ComponentModel.DataAnnotations;

namespace Mahtan.Assets.Values.Enums
{
    public enum ProductSizes
    {
        [Display(Name = "")]
        None = 0,
        [Display(Name = "XS")]
        XS = 1,
        [Display(Name = "S")]
        S = 2,
        [Display(Name = "M")]
        M = 4,
        [Display(Name = "L")]
        L = 8,
        [Display(Name = "XL")]
        XL = 16,
        [Display(Name = "XXL")]
        XXL = 32
    }
}
