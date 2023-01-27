using System.ComponentModel.DataAnnotations;

namespace Mahtan.Assets.Values.Enums
{
    public enum SortOrders
    {
        [Display(Name = "محبوب ترین")]
        Popularity,
        [Display(Name = "ارزان ترین")]
        PriceAsc,
        [Display(Name = "گران ترین")]
        PriceDesc,
        [Display(Name = "پر فروش ترین")]
        MostSell
    }
}
