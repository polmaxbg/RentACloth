using System.Collections.Generic;
using RentACloth.Services.Contracts;

namespace RentACloth.Models.ProductsViewModel
{
    public class IndexViewModel
    {
        public IEnumerable<IndexProductViewModel> Products { get; set; }
    }
}