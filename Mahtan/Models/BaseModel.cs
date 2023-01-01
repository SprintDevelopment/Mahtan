using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahtan.Models
{
    public class BaseModel
    {
        [NotMapped]
        public bool IsSelected { get; set; }

        [Display(Name = "ردیف نمایش")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} را وارد کنید")]
        public int DisplayOrder { get; set; }

        public BaseModel()
        {
        }

        public BaseModel Clone() => (BaseModel)MemberwiseClone();
    }
}
