using AutoMapper.Configuration.Conventions;
using Mahtan.Assets.Values.Constants;
using MessagePack;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahtan.Models
{
    [PrimaryKey(nameof(PersonId), nameof(PropertyId))]
    public class Datum : BaseModel
    {
        [Required]
        public int PersonId { get; set; }

        [Required]
        public short PropertyId { get; set; }

        [ForeignKey(nameof(PropertyId))]
        public Property Property { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(LengthConstants.VERY_LARGE_STRING)]
        public string Value { get; set; }
    }
}
