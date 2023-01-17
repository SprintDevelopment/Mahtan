using Mahtan.Assets.Values.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahtan.Models
{
    public class ProductReview : BaseModel
    {
        [Key]
        public long ProductReviewId { get; set; }

        [Required]
        public string WriterUsername { get; set; }

        [ForeignKey(nameof(WriterUsername))]
        public Profile WriterProfile { get; set; }

        [Display(Name = "امتیاز")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [Range(0, 5, ErrorMessage = "{0} باید عددی بین  {1} و {2} باشد")]
        public int Rate { get; set; }

        [Required]
        public DateTime ReviewDate { get; set; }

        [Display(Name = "متن نظر")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(LengthConstants.VERY_LARGE_STRING, ErrorMessage = "حداکثر طول {0}، {1} کاراکتر است")]
        public string Comment { get; set; }
    }
}
