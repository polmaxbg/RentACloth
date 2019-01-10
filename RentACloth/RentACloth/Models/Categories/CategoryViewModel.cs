using System.ComponentModel.DataAnnotations;

namespace RentACloth.Models.Categories
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int ChildCategoriesCount { get; set; }
    }
}