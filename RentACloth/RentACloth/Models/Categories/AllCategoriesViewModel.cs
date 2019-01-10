using System.Collections.Generic;
using RentACloth.Controllers;
using RentACloth.Models.ChildCategories;

namespace RentACloth.Models.Categories
{
    public class AllCategoriesViewModel
    {
        public ICollection<AllChildCategoryViewModel> ChildCategoryViewModel { get; set; }

        public ICollection<CategoryViewModel> CategoryViewModels { get; set; }
    }
}