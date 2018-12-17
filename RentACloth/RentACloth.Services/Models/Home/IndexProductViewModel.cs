using AutoMapper;
using RentACloth.Data.Models.Entities;
using RentACloth.Services.Mapping;

namespace RentACloth.Services.Models.Home
{
    public class IndexProductViewModel:IMapFrom<Shoe>,IMapTo<Shoe>,
        IMapFrom<Cloth>,IMapTo<Cloth>, IMapFrom<Accessories>, IMapTo<Accessories>,
        IMapFrom<Watch>, IMapTo<Watch>, IHaveCustomMappings
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string BrandName { get; set; }
        public string EvenType { get; set; }
        public string CategoryName { get; set; }
        public string Size { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Shoe, IndexProductViewModel>()
                .ForMember(x => x.EvenType, x => x.MapFrom(y => y.EventType))
                .ForMember(x => x.CategoryName, x => x.MapFrom(y => y.Category.Name))
                .ForMember(x=>x.BrandName,x=>x.MapFrom(y=>y.Brand.Name));


            configuration.CreateMap<Cloth, IndexProductViewModel>()
                .ForMember(x => x.EvenType, x => x.MapFrom(y => y.EventType))
                .ForMember(x => x.CategoryName, x => x.MapFrom(y => y.Category.Name))
                .ForMember(x => x.BrandName, x => x.MapFrom(y => y.Brand.Name));


            configuration.CreateMap<Accessories, IndexProductViewModel>()
                .ForMember(x => x.EvenType, x => x.MapFrom(y => y.EventType))
                .ForMember(x => x.CategoryName, x => x.MapFrom(y => y.Category.Name))
                .ForMember(x => x.BrandName, x => x.MapFrom(y => y.Brand.Name));


            configuration.CreateMap<Watch, IndexProductViewModel>()
                .ForMember(x => x.EvenType, x => x.MapFrom(y => y.EventType))
                .ForMember(x => x.CategoryName, x => x.MapFrom(y => y.Category.Name))
                .ForMember(x => x.BrandName, x => x.MapFrom(y => y.Brand.Name));


            //configuration.CreateMap<Shoe, IndexProductViewModel>()
            //    .ForMember(x => x.ShoeSize, x => x.MapFrom(y => y.Size));

            //configuration.CreateMap<Cloth, IndexProductViewModel>()
            //    .ForMember(x => x.Size, x => x.MapFrom(y => y.Size));
        }
    }
}