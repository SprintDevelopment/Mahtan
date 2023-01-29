using Mahtan.Assets.Attributes;
using Mahtan.Assets.Values;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahtan.Models
{
    [Model(SingleEntityTitle = "قالب محتوا", MultipleEntitiesTitle = "قالب های محتوا")]
    public class ContentTemplate : BaseModel
    {
        [Key]
        public short ContentTemplateId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string TemplateUrl { get; set; }

        [NotMapped]
        public string TemplateAbsolutePath => string.Format("/{0}/{1}", Addresses.ContentTemplatesPath.Replace('\\', '/'), TemplateUrl);
    }
}
