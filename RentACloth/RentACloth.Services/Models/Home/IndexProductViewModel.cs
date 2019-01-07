using AutoMapper;
using RentACloth.Data.Models;
using RentACloth.Data.Models.Entities;
using RentACloth.Services.Mapping;

namespace RentACloth.Services.Models.Home
{
    public class IndexProductViewModel:IMapFrom<Shoe>,IMapTo<Shoe>,
        IMapFrom<Cloth>,IMapTo<Cloth>, IMapFrom<Accessories>, IMapTo<Accessories>,
        IMapFrom<Watch>, IMapTo<Watch>,IMapTo<Product>,IMapFrom<Product>, IHaveCustomMappings
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string BrandName { get; set; }
        public string EvenType { get; set; }
        public string CategoryName { get; set; }
        public string Size { get; set; }

        public string ImageUrl { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Shoe, IndexProductViewModel>()
                .ForMember(x => x.EvenType, x => x.MapFrom(y => y.EventType))
                //.ForMember(x => x.CategoryName, x => x.MapFrom(y => y.ChildCategory.Product.Name))
                .ForMember(x=>x.BrandName,x=>x.MapFrom(y=>y.BrandName));


            configuration.CreateMap<Cloth, IndexProductViewModel>()
                .ForMember(x => x.EvenType, x => x.MapFrom(y => y.EventType))
                //.ForMember(x => x.CategoryName, x => x.MapFrom(y => y.ChildCategory.Product.Name))
                .ForMember(x => x.BrandName, x => x.MapFrom(y => y.BrandName));


            configuration.CreateMap<Accessories, IndexProductViewModel>()
                .ForMember(x => x.EvenType, x => x.MapFrom(y => y.EventType))
                //.ForMember(x => x.CategoryName, x => x.MapFrom(y => y.ChildCategory.Product.Name))
                .ForMember(x => x.BrandName, x => x.MapFrom(y => y.BrandName));


            configuration.CreateMap<Watch, IndexProductViewModel>()
                .ForMember(x => x.EvenType, x => x.MapFrom(y => y.EventType))
                //.ForMember(x => x.CategoryName, x => x.MapFrom(y => y.ChildCategory.Product.Name))
                .ForMember(x => x.BrandName, x => x.MapFrom(y => y.BrandName));

            configuration.CreateMap<Product, IndexProductViewModel>()
                .ForMember(x => x.ImageUrl, x => x.MapFrom(y => y.ImageUrl));
        }
    }
}