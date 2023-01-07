using Mahtan.Models;
using System.Collections.Generic;

namespace Mahtan.ViewModels
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
