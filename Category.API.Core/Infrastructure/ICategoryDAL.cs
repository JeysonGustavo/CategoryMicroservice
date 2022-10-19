using Category.API.Core.Models.Domain;

namespace Category.API.Core.Infrastructure
{
    public interface ICategoryDAL
    {
        bool SaveChanges();

        IEnumerable<CategoryModel> GetAllCategories();

        CategoryModel? GetCategoryById(int id);

        void CreateCategory(CategoryModel category);
    }
}
