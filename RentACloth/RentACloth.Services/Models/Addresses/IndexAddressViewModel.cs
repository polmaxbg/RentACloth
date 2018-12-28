using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using RentACloth.Data.Models;
using RentACloth.Services.Mapping;

namespace RentACloth.Services.Models.Addresses
{
    public class IndexAddressViewModel:IMapFrom<Data.Models.Address>,IMapTo<Data.Models.Address>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Display(Name = "Адрес за доставка")]
        [Required(ErrorMessage = "Моля въведете \"{0}\".")]
        public string DeliveryAddress { get; set; }

        [Display(Name = "Данни към адреса")]
        public string AddressDetails { get; set; }

        [Display(Name = "Град")]
        [Required(ErrorMessage = "Моля въведете \"{0}\".")]
        public string City { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Address, IndexAddressViewModel>()
                .ForMember(x => x.City, x => x.MapFrom(y => y.City))
                .ForMember(x => x.DeliveryAddress, x => x.MapFrom(y => y.Street))
                .ForMember(x => x.AddressDetails, x => x.MapFrom(y => y.AddressDetails));
        }
    }
}
