using Mahtan.Assets.Attributes;
using Mahtan.Assets.Values;
using Mahtan.Assets.Values.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Mahtan.Models
{
    [Model(SingleEntityTitle = "محصول", MultipleEntitiesTitle = "محصولات")]
    public class Product : BaseModel
    {
        [Key]
        public int ProductId { get; set; }

        [Display(Name = "نام محصول")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(LengthConstants.MEDIUM_STRING, ErrorMessage = "حداکثر طول {0}، {1} کاراکتر است")]
        public string Name { get; set; }


        [Display(Name = "دسته محصول")]
        [Required(ErrorMessage = "{0} را انتخاب کنید")]
        public short CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [Range(0, int.MaxValue, ErrorMessage = "{0} باید عددی بین  {1} و {2} باشد")]
        public long Price { get; set; }

        [Display(Name = "درصد تخفیف")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [Range(0, 100, ErrorMessage = "{0} باید عددی بین  {1} و {2} باشد")]
        public int DiscountPercent { get; set; }

        [NotMapped]
        public long PriceAfterDiscount { get => Price * (100 - DiscountPercent) / 100; }

        public virtual ICollection<ProductImage> Images { get; set; }

        [NotMapped]
        public string FirstThumbImageFullPath => (Images?.FirstOrDefault() ?? new ProductImage()).ImageThumbFullPath;
        
        [NotMapped]
        public string FirstLargeImageFullPath => (Images?.FirstOrDefault() ?? new ProductImage()).ImageLargeFullPath;

        [Display(Name = "توضیحات اختیاری")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [MaxLength(LengthConstants.VERY_LARGE_STRING, ErrorMessage = "حداکثر طول {0}، {1} کاراکتر است")]
        public string OptionalComment { get; set; }

        [NotMapped]
        public string FarsiSlug => Regex.Replace(Name, @"\s", "-");
    }
}
