using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahtan.Models
{
    public class CartItem : BaseModel
    {
        [Key]
        public long CartItemId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "{0} باید عددی بین  {1} و {2} باشد")]
        public int Qty { get; set; }

        [Required]
        [Range(0, long.MaxValue, ErrorMessage = "{0} باید عددی بین  {1} و {2} باشد")]
        public long Price { get; set; }

        [NotMapped]
        public long Total { get; set; }
    }
}
