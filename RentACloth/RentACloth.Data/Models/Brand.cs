using System;
using System.Collections.Generic;
using System.Text;

namespace RentACloth.Data.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
