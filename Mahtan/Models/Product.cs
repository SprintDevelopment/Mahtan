using Mahtan.Assets.Attributes;
using Mahtan.Assets.Dtos;
using Mahtan.Assets.Extensions;
using Mahtan.Assets.Values;
using Mahtan.Assets.Values.Constants;
using Mahtan.Assets.Values.Enums;
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

        [Display(Name = "برند محصول")]
        public short? BrandId { get; set; }

        [ForeignKey(nameof(BrandId))]
        public Brand Brand { get; set; }

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
        public virtual ICollection<ProductReview> Reviews { get; set; }

        [NotMapped]
        public string FirstThumbImageFullPath => (Images?.FirstOrDefault() ?? new ProductImage()).ImageThumbFullPath;

        [NotMapped]
        public string FirstLargeImageFullPath => (Images?.FirstOrDefault() ?? new ProductImage()).ImageLargeFullPath;

        [Display(Name = "کد اختیاری")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [MaxLength(LengthConstants.SMALL_STRING, ErrorMessage = "حداکثر طول {0}، {1} کاراکتر است")]
        public string OptionalCode { get; set; } = "";

        [Display(Name = "توضیحات اختیاری")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [MaxLength(LengthConstants.VERY_LARGE_STRING, ErrorMessage = "حداکثر طول {0}، {1} کاراکتر است")]
        public string OptionalComment { get; set; }

        [Display(Name = "رنگ های قابل عرضه")]
        public ProductColors Colors { get; set; } = ProductColors.None;

        [Display(Name = "اندازه های قابل عرضه")]
        public long Sizes { get; set; } = 0;

        [NotMapped]
        public ProductSizeItem[] SizeItems 
        { 
            get => Category?.ProductSize?.SizeItems?.Select(item => { item.IsSelected = ((long)Math.Pow(2, item.DisplayOrder) & Sizes) == (long)Math.Pow(2, item.DisplayOrder); return item; }).ToArray() ?? new ProductSizeItem[] { };
            set => Sizes = (long)(value ?? new ProductSizeItem[] { }).Select(item => item.IsSelected ? Math.Pow(2, item.DisplayOrder) : 0).Sum(); 
        }

        [Display(Name = "محصول در حال حاضر فعال است.")]
        public bool IsActive { get; set; } = true;

        [NotMapped]
        public string FarsiSlug => Regex.Replace(Name, @"\s", "-");
    }
}
