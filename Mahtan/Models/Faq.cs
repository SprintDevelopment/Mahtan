using Mahtan.Assets.Attributes;
using Mahtan.Assets.Values.Constants;
using Mahtan.Assets.Values.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Mahtan.Models
{
    [Model(SingleEntityTitle = "سوال متداول", MultipleEntitiesTitle = "سوالات متداول")]
    public class Faq : BaseModel
    {
        [Key]
        public short FaqId { get; set; }

        [Display(Name = "گروه پرسش")]
        public FaqGroups FaqGroup { get; set; }

        [Display(Name = "متن پرسش")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(LengthConstants.VERY_LARGE_STRING, ErrorMessage = "حداکثر طول {0}، {1} کاراکتر است")]
        public string QuestionText { get; set; }

        [Display(Name = "متن پاسخ")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(LengthConstants.VERY_LARGE_STRING, ErrorMessage = "حداکثر طول {0}، {1} کاراکتر است")]
        public string AnswerText { get; set; }

        [Display(Name = "ردیف نمایش")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public int DisplayOrder { get; set; }

        public Faq()
        {
        }
    }
}
