using System.Collections.Generic;
using RentACloth.Services.Models.Addresses;

namespace RentACloth.Controllers
{
    public class OrdersAddressViewModel
    {
        public IEnumerable<IndexAddressViewModel> Addresses { get; set; }
    }
}