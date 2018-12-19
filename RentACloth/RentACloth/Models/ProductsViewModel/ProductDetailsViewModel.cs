using AutoMapper;
using RentACloth.Data.Models;
using RentACloth.Data.Models.Entities;
using RentACloth.Services.Mapping;

namespace RentACloth.Models.ProductsViewModel
{
    public class ProductDetailsViewModel:IMapFrom<Product>,IMapTo<Product>,
        IMapFrom<Shoe>, IMapTo<Shoe>,
        IMapFrom<Cloth>, IMapTo<Cloth>,
        IHaveCustomMappings
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string EventType { get; set; }
        public string BrandName { get; set; }
        public string Size { get; set; }
        public string CategoryName { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {

            configuration.CreateMap<Product, ProductDetailsViewModel>()
                .ForMember(x => x.EventType, x => x.MapFrom(y => y.EventType))
                .ForMember(x => x.CategoryName, x => x.MapFrom(y => y.Category.Name));

            //configuration.CreateMap<Cloth, ProductDetailsViewModel>()
            //    .ForMember(x => x.Size, x => x.MapFrom(y => y.Size));
        }
    }
    
}