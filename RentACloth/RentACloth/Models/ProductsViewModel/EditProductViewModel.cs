using AutoMapper;
using RentACloth.Data.Models;
using RentACloth.Services.Mapping;

namespace RentACloth.Models.ProductsViewModel
{
    public class EditProductViewModel : IMapFrom<Product>, IMapTo<Product>, IHaveCustomMappings
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public string ProductType { get; set; }
        public int ChildCategoryId { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Product, EditProductViewModel>()
                .ForMember(x => x.Name, x => x.MapFrom(y => y.Name))
                .ForMember(x => x.ProductType, x => x.MapFrom(y => y.ProductType))
                .ForMember(x=>x.CategoryName,x=>x.MapFrom(y=>y.CategoryName))
                .ForMember(x=>x.BrandName,x=>x.MapFrom(y=>y.BrandName))
                .ForMember(x=>x.ImageUrl,x=>x.MapFrom(y=>y.ImageUrl));
        }
    }
}