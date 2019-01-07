using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using RentACloth.Data.Models;
using RentACloth.Services.Mapping;
using RentACloth.Services.Models.Addresses;

namespace RentACloth.Models.Оrders
{
    public class OrdersAddressViewModel:IMapFrom<Address>,IMapTo<Address>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Display(Name = "Адрес за доставка")]
        [Required(ErrorMessage = "Въведете \"{0}\".")]
        public string DeliveryAddress { get; set; }


        [Display(Name = "Допълнение към адреса")]
        [Required(ErrorMessage = "Въведете \"{0}\".")]
        public string AddressDetails { get; set; }


        [Display(Name = "Град")]
        [Required(ErrorMessage = "Въведете \"{0}\".")]
        public string City { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Address, OrdersAddressViewModel>()
                .ForMember(x => x.City, x => x.MapFrom(y => y.City))
                .ForMember(x => x.DeliveryAddress, x => x.MapFrom(y => y.Street))
                .ForMember(x => x.AddressDetails, x => x.MapFrom(y => y.AddressDetails));
        }
    }
}