using RentACloth.Data.Models;
using RentACloth.Services.Mapping;

namespace RentACloth.Models.Home
{
    public class IndexChildCategoryViewModel:IMapFrom<ChildCategory>,IMapTo<ChildCategory>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}