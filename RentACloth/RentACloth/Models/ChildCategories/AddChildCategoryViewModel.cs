using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RentACloth.Data.Models;

namespace RentACloth.Controllers
{
    public class AddChildCategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Попълнете {0}!")]
        [Display(Name = "Име")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Изберете {0}!")]
        [Display(Name = "Главна категория")]
        public int? CategoryId { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}