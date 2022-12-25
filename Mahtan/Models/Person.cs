using Mahtan.Assets.Values.Constants;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Mahtan.Models
{
    [Index(nameof(NationalCode), IsUnique = true)]
    public class Person : BaseModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid PersonalGuid { get; set; }

        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(LengthConstants.NATIONAL_IDS, ErrorMessage = "حداکثر طول {0}، {1} کاراکتر است")]
        public string NationalCode { get; set; }

        [Display(Name = "کاربر مرتبط")]
        [Required]
        public string RelatedUserId { get; set; }

        [Required]
        public DateTime DateTimeCreated { get; set; } = DateTime.Now;
    }
}
