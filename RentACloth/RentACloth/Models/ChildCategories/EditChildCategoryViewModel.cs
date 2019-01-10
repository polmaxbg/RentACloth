using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RentACloth.Data.Models;
using RentACloth.Services.Mapping;

namespace RentACloth.Models.ChildCategories
{
    public class EditChildCategoryViewModel:IMapFrom<ChildCategory>,IMapTo<ChildCategory>
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Попълнете {0}!")]
        [Display(Name = "Име")]
        public string Name { get; set; }
        

        [Required(ErrorMessage = "Изберете {0}!")]
        [Display(Name = "Основна категория")]
        public int? CategoryId { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}