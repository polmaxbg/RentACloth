using System.Collections.Generic;
using RentACloth.Data.Models;
using RentACloth.Services.Mapping;

namespace RentACloth.Models.Home
{
    public class IndexCategoryViewModel:IMapFrom<Category>,IMapTo<Category>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<IndexChildCategoryViewModel> ChildCategories { get; set; }
    }
}