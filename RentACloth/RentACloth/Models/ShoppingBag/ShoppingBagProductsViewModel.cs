using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RentACloth.Data.Models;
using RentACloth.Services.Mapping;
using RentACloth.Data.Models;

namespace RentACloth.Models.ShoppingBag
{
    public class ShoppingBagProductsViewModel:IMapFrom<Product>, IMapTo<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
