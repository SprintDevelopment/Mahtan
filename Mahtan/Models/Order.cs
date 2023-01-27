using Mahtan.Assets.Attributes;
using Mahtan.Assets.Values.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahtan.Models
{
    [Model(SingleEntityTitle = "سفارش", MultipleEntitiesTitle = "سفارشات")]
    public class Order : BaseModel
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public string OrderNumber { get; set; } = Convert.ToBase64String(Guid.NewGuid().ToByteArray());

        [Required]
        public string Username { get; set; }

        [ForeignKey(nameof(Username))]
        public Profile UserProfile { get; set; }

        [Required]
        public DateTime CreateDateTime { get; set; }

        [Required]
        public string DeliveryAddress { get; set; }

        [Required]
        public string DeliveryCode { get; set; }

        [Required]
        public DateTime ToDeliverDate { get; set; }

        [Required]
        public DeliveryTimeRanges ToDeliverTimeRange { get; set; }

        [Required]
        public DateTime DeliveredDateTime { get; set; }

        [Required]
        public OrderStates OrderState { get; set; }

        public virtual ICollection<OrderItem> Items { get; set; }

        [NotMapped]
        public long TotalPrice => ((Items ?? Enumerable.Empty<OrderItem>()).Sum(i => i.Qty * i.Price));
    }
}
