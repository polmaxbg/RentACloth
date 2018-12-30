using System.Collections.Generic;
using RentACloth.Services.Models.Addresses;

namespace RentACloth.Models.Оrders
{
    public class OrdersAddressViewModel
    {
        public IEnumerable<IndexAddressViewModel> Addresses { get; set; }
    }
}