using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RentACloth.Services.Models.Addresses;

namespace RentACloth.Controllers
{
    public class CreateOrderViewModel
    {
        public List<IndexAddressViewModel> OrderAddressesViewModel { get; set; }
        public IndexAddressViewModel OrderAdressViewModel { get; set; }

        [Display(Name = "Адрес на получаване")]
        [Required(ErrorMessage = "Моля изберете \"{0}\".")]
        public int? DeliveryAddressId { get; set; }

        [Display(Name = "Име на получателя")]
        [Required(ErrorMessage = "Моля въведете \"{0}\".")]
        public string FullName { get; set; }

        [Display(Name = "GSM номер")]
        [Required(ErrorMessage = "Моля въведете \"{0}\".")]
        public string PhoneNumber { get; set; }
    }
}