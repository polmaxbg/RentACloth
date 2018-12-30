using AutoMapper;
using RentACloth.Controllers;
using RentACloth.Data.Models;

namespace RentACloth.MappingConfiguration
{
    public class RentAClothProfile:Profile
    {
        public RentAClothProfile()
        {

            //this.CreateMap<Order, MyOrderViewModel>();

            //this.CreateMap<Product, MyOrderViewModel>()
            //    .ForMember(x => x.ProductName, x => x.MapFrom(y => y.Name))
            //    .ForMember(x => x.Price, x => x.MapFrom(y => y.Price));
        }
    }
}
