using Category.API.Core.Models.Domain;

namespace Category.API.Core.Manager
{
    public interface ICategoryManager
    {
        bool SaveChanges();

        IEnumerable<CategoryModel> GetAllCategories();

        CategoryModel? GetCategoryById(int id);

        void CreateCategory(CategoryModel category);
    }
}
