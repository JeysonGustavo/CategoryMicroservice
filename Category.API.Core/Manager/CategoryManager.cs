using Category.API.Core.Infrastructure;
using Category.API.Core.Models.Domain;

namespace Category.API.Core.Manager
{
    public class CategoryManager : ICategoryManager
    {
        private readonly ICategoryDAL _categoryDAL;

        public CategoryManager(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }

        public bool SaveChanges() => _categoryDAL.SaveChanges();

        public void CreateCategory(CategoryModel category) => _categoryDAL.CreateCategory(category);

        public IEnumerable<CategoryModel> GetAllCategories() => _categoryDAL.GetAllCategories();

        public CategoryModel? GetCategoryById(int id) => _categoryDAL.GetCategoryById(id);
    }
}
