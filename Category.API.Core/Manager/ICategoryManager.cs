using Category.API.Core.Models.Domain;

namespace Category.API.Core.Manager
{
    public interface ICategoryManager
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<CategoryModel>> GetAllCategories();

        Task<CategoryModel?> GetCategoryById(int id);

        Task CreateCategory(CategoryModel category);
    }
}
