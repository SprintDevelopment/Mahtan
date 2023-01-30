using Mahtan.Models;
using System.ComponentModel.DataAnnotations;

namespace Mahtan.ViewModels
{
    public class ProductMoreInfoViewModel
    {
        public Product Product { get; set; }

        public IEnumerable<ContentTemplate> ContentTemplates { get; set; }

        [Display(Name = "قالب انتخاب شده")]
        public short SelectedTemplateId { get; set; }
    }
}
