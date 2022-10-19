using Category.API.Core.Models.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Category.API.Infrastructure.Data
{
    public static class InitializeDb
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new CategoryModel() { Id = 1, CategoryName = "Microsoft" },
                    new CategoryModel() { Id = 2, CategoryName = "Docker" },
                    new CategoryModel() { Id = 3, CategoryName = "Linux" }
                    );

                context.SaveChanges();
            }
        }
    }
}
