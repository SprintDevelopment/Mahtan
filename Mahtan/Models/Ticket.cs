using Mahtan.Assets.Values.Enums;
using System.ComponentModel.DataAnnotations;

namespace Mahtan.Models
{
    public class Ticket
    {
        [Key]
        public long TicketId { get; set; }
    }
}
