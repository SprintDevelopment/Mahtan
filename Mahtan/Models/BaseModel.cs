using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahtan.Models
{
    public class BaseModel
    {
        [NotMapped]
        public bool IsSelected { get; set; }

        public BaseModel()
        {
        }

        public BaseModel Clone() => (BaseModel)MemberwiseClone();
    }
}
