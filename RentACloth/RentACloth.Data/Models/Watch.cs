using System;
using System.Collections.Generic;
using System.Text;

namespace RentACloth.Data.Models
{
    public class Watch
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public EventType EventType { get; set; }

    }
}
