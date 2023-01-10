using System.ComponentModel.DataAnnotations;

namespace Mahtan.Models
{
    public class Order : BaseModel
    {
        [Key]
        public int OrderId { get; set; }
    }
}
