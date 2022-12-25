using Mahtan.Assets.Values.Constants;
using System.ComponentModel.DataAnnotations;

namespace Mahtan.Models
{
    public class Image : BaseModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(LengthConstants.FILE_EXTENSION_MAX_LENGTH)]
        public string Extension { get; set; }

        [Required]
        public int SizeInBytes { get; set; }
    }
}
