using AutoMapper;
using RentACloth.Data.Models;
using RentACloth.Services.Mapping;

namespace RentACloth.Models.ChildCategories
{
    public class AllChildCategoryViewModel:IMapFrom<Category>,IMapTo<Category>,IHaveCustomMappings
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public int ProductsCount { get; set; }
        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Category, AllChildCategoryViewModel>()
                .ForMember(x => x.CategoryName, x => x.MapFrom(y => y.Name));
        }
    }
}