using Mahtan.Assets.Values.Constants;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Mahtan.Models
{
    public class User : IdentityUser
    {
        public DateTime RegisterDateTime { get; set; }

        [Required]
        public string MobileConfirmationCode { get; set; }
    }
}
