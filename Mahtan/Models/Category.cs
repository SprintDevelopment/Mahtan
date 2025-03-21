﻿using Mahtan.Assets.Attributes;
using Mahtan.Assets.Extensions;
using Mahtan.Assets.Values;
using Mahtan.Assets.Values.Constants;
using Mahtan.Assets.Values.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahtan.Models
{
    [Model(SingleEntityTitle = "دسته محصول", MultipleEntitiesTitle = "دسته های محصول")]
    public class Category : BaseModel
    {
        [Key]
        public short CategoryId { get; set; }

        [Display(Name = "دسته بالاتر", Description = "در صورتی که دسته جدید زیرشاخه دسته دیگری است، آن را انتخاب کنید")]
        public short? ParentCategoryId { get; set; }

        [Display(Name = "عنوان دسته")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(LengthConstants.MEDIUM_STRING, ErrorMessage = "حداکثر طول {0}، {1} کاراکتر است")]
        public string Title { get; set; }

        [Display(Name = "عنوان واحد شمارش")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(LengthConstants.MEDIUM_STRING, ErrorMessage = "حداکثر طول {0}، {1} کاراکتر است")]
        public string CountUnitTitle { get; set; } = "عدد";

        [Display(Name = "واحد اندازه گیری")]
        public short? ProductSizeId { get; set; }

        [ForeignKey(nameof(ProductSizeId))]
        public ProductSize ProductSize { get; set; }

        [Display(Name = "آیکن دسته")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string IconGuid { get; set; }

        [NotMapped]
        public string IconFullPath => string.Format("/{0}/{1}", Addresses.CategoryIconsPath.Replace('\\', '/'), !IconGuid.IsNullOrWhitespace() ? IconGuid : "no-image.png");

        [Display(Name = "توضیحات اختیاری")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [MaxLength(LengthConstants.VERY_LARGE_STRING, ErrorMessage = "حداکثر طول {0}، {1} کاراکتر است")]
        public string OptionalComment { get; set; } = "";

        public Category()
        {
        }
    }
}
