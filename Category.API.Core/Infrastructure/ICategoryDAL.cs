using Category.API.Core.Models.Domain;

namespace Category.API.Core.Infrastructure
{
    public interface ICategoryDAL
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<CategoryModel>> GetAllCategories();

        Task<CategoryModel?> GetCategoryById(int id);

        Task CreateCategory(CategoryModel category);
    }
}
