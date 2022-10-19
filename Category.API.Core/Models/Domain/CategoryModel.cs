using System.ComponentModel.DataAnnotations;

namespace Category.API.Core.Models.Domain
{
    public class CategoryModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string? CategoryName { get; set; }
    }
}
