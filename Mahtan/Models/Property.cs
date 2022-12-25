using Mahtan.Assets.Values.Constants;
using Mahtan.Assets.Values.Enums;
using System.ComponentModel.DataAnnotations;

namespace Mahtan.Models
{
    public class Property : BaseModel
    {
        [Key]
        public short Id { get; set; }

        [Required]
        public short PropertyCatId { get; set; }

        [Required]
        public PropertyTypes Type { get; set; }

        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(LengthConstants.MEDIUM_STRING)]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = true)]
        [MaxLength(LengthConstants.LARGE_STRING)] 
        public string Description { get; set; } = string.Empty;


        [Required(AllowEmptyStrings = true)]
        [MaxLength(LengthConstants.VERY_LARGE_STRING)]
        public string Value { get; set; }
    }
}
