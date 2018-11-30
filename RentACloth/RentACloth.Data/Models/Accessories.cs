using System;
using System.Collections.Generic;
using System.Text;

namespace RentACloth.Data.Models
{
    public class Accessories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public EventType EventType { get; set; }

    }
}
