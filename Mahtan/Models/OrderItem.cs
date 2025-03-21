﻿using System.ComponentModel.DataAnnotations.Schema;
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
        [Range(0, int.MaxValue, ErrorMessage = "{0} باید عددی بین  {1} و {2} باشد")]
        public int Qty { get; set; }

        [Required]
        [Range(0, long.MaxValue, ErrorMessage = "{0} باید عددی بین  {1} و {2} باشد")]
        public long Price { get; set; }
    }
}
