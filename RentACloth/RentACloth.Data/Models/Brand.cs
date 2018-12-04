using System;
using System.Collections.Generic;
using System.Text;

namespace RentACloth.Data.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name{ get; set; }

        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
        
    }
}
