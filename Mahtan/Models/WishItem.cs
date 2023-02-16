using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mahtan.Models
{
    public class WishItem : BaseModel
    {
        [Key]
        public long WishItemId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
    }
}
