using Mahtan.Assets.Attributes;
using Mahtan.Assets.Values.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahtan.Models
{
    [Model(SingleEntityTitle = "منطقه", MultipleEntitiesTitle = "مناطق")]
    public class District : BaseModel
    {
        [Key]
        public int DistrictId { get; set; }

        [Display(Name = "نام محله")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(LengthConstants.MEDIUM_STRING, ErrorMessage = "حداکثر طول {0}، {1} کاراکتر است")]
        public string DistrictName { get; set; }

        public District()
        {
        }
    }
}
