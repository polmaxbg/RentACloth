using System;
using System.Collections.Generic;
using System.Text;
using RentACloth.Data.Models;
using RentACloth.Services.Mapping;

namespace RentACloth.Services.Contracts
{
    public interface IProductsService
    {
        IEnumerable<IndexProductViewModel> All();
    }

    public class IndexProductViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string BrandName { get; set; }
        public string EvenType { get; set; }
    }
}
