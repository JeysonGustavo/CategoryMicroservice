using Category.API.Core.Infrastructure;
using Category.API.Core.Models.Domain;
using Category.API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Category.API.Infrastructure.DAL
{
    public class CategoryDAL : ICategoryDAL
    {
        private readonly AppDbContext _context;

        public CategoryDAL(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateCategory(CategoryModel category)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                if (category is null)
                    throw new ArgumentNullException(nameof(category));

                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
        }

        public async Task<IEnumerable<CategoryModel>> GetAllCategories() => await _context.Categories.ToListAsync();

        public async Task<CategoryModel?> GetCategoryById(int id) => await _context.Categories.FirstOrDefaultAsync(c => c.Id.Equals(id));

        public async Task<bool> SaveChanges() => await _context.SaveChangesAsync() > 0;

    }
}
