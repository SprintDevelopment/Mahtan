using Mahtan.Assets.Values.Constants;
using System.ComponentModel.DataAnnotations;

namespace Mahtan.Models
{
    public class PropertyCat
    {
        [Key]
        public short Id { get; set; }

        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(LengthConstants.MEDIUM_STRING)]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = true)]
        [MaxLength(LengthConstants.LARGE_STRING)]
        public string Description { get; set; } = string.Empty;
    }
}
