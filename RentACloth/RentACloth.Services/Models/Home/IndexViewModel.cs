using System.Collections.Generic;

namespace RentACloth.Services.Models.Home
{
    public class IndexViewModel
    {
        public IEnumerable<IndexProductViewModel> Products { get; set; }
    }
}