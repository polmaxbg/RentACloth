using System.Collections.Generic;

namespace RentACloth.Models.Оrders
{
    public class MyOrdersViewModel
    {
        public IEnumerable<MyOrderViewModel> Orders { get; set; }
    }
}