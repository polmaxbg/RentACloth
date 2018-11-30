using System;
using System.Collections.Generic;
using System.Text;

namespace RentACloth.Data.Models
{
    public class Clothes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public string BrandName { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public EventType EventType { get; set; }
    }
}
