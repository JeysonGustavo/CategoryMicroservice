using Category.API.Core.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Category.API.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<CategoryModel> Categories { get; set; }
    }
}
