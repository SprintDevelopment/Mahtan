using Mahtan.Models;
using Microsoft.EntityFrameworkCore;

namespace Mahtan.Data.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> FindAllExceptItselfAndChildren(short categoryId);
    }

    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context) { }

        public ApplicationDbContext DatabaseContext
        {
            get { return Context as ApplicationDbContext; }
        }

        public IEnumerable<Category> FindAllExceptItselfAndChildren(short categoryId = 0) 
        {
            if (categoryId == 0)
                return Find();

            var toRemoveCategoryIds = DatabaseContext.Categories
                .Where(c => c.CategoryId == categoryId)
                .Select(c => c.CategoryId)
                .ToList();

            for (int i = 0; i < toRemoveCategoryIds.Count(); i++)
            {
                toRemoveCategoryIds.AddRange(
                    DatabaseContext.Categories
                    .Where(c => c.ParentCategoryId == toRemoveCategoryIds[i])
                    .Select(c => c.CategoryId));
            }

            return DatabaseContext.Categories.Where(c => !toRemoveCategoryIds.Contains(c.CategoryId)).AsEnumerable();
        }

        public new void Remove(Category category)
        {
             DatabaseContext.Categories
                .Where(c => c.ParentCategoryId == category.CategoryId)
                .ForEachAsync(c => c.ParentCategoryId = category.ParentCategoryId).Wait();

            DatabaseContext.Categories.Remove(category);
            DatabaseContext.SaveChanges();
        }
    }
}
