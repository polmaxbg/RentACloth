using AutoMapper;
using RentACloth.Data.Models;
using RentACloth.Services.Mapping;

namespace RentACloth.Models.ShoppingBag
{
    public class ShoppingBagProductsViewModel:IMapFrom<Product>, IMapTo<Product>,IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }
        public string ImageUrl { get; set; }
        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Product, ShoppingBagProductsViewModel>()
                .ForMember(x => x.ImageUrl, x => x.MapFrom(y => y.ImageUrl));
        }
    }
}
