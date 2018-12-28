using System;
using System.Collections.Generic;
using System.Text;
using RentACloth.Data.Models.Entities;
using RentACloth.Data.Models.Enums;
using RentACloth.Services.Mapping;

namespace RentACloth.Data.Models
{
    public abstract class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public EventType EventType { get; set; }
        public string ProductType { get; set; }
        public string Size { get; set; }

        public string BrandName { get; set; }
        public Brand Brand { get; set; }
        public int BrandId { get; set; }

        public string CategoryName { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }


        public virtual ICollection<ShoppingBagProduct> ShoppingBagProducts { get; set; } = new HashSet<ShoppingBagProduct>();

    }
}
