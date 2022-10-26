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

        public async Task<bool> SaveChanges() => await _categoryDAL.SaveChanges();

        public async Task CreateCategory(CategoryModel category) => await _categoryDAL.CreateCategory(category);

        public async Task<IEnumerable<CategoryModel>> GetAllCategories() => await _categoryDAL.GetAllCategories();

        public async Task<CategoryModel?> GetCategoryById(int id) => await _categoryDAL.GetCategoryById(id);
    }
}
