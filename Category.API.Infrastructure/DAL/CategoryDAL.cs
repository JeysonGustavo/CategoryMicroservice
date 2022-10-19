using Category.API.Core.Infrastructure;
using Category.API.Core.Models.Domain;
using Category.API.Infrastructure.Data;

namespace Category.API.Infrastructure.DAL
{
    public class CategoryDAL : ICategoryDAL
    {
        private readonly AppDbContext _context;

        public CategoryDAL(AppDbContext context)
        {
            _context = context;
        }

        public void CreateCategory(CategoryModel category)
        {
            if (category is null)
                throw new ArgumentNullException(nameof(category));

            _context.Categories.Add(category);
        }

        public IEnumerable<CategoryModel> GetAllCategories() => _context.Categories.ToList();

        public CategoryModel? GetCategoryById(int id) => _context.Categories.FirstOrDefault(c => c.Id.Equals(id));

        public bool SaveChanges() => _context.SaveChanges() > 0;
    }
}
