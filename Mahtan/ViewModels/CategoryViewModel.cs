using Mahtan.Assets.Dtos;
using Mahtan.Models;
using System.Collections.Generic;

namespace Mahtan.ViewModels
{
    public class CategoryViewModel
    {
        public Category Category { get; set; }
        public IEnumerable<Category> ParentCategories { get; set; }
        public IEnumerable<ProductSize> ProductSizes { get; set; }
    }
}
