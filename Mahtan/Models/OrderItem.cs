using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mahtan.Models
{
    public class OrderItem : BaseModel
    {
        [Key]
        public long OrderItemId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        [Required]
        public int Qty { get; set; }

        [Required]
        public long Price { get; set; }
    }
}
