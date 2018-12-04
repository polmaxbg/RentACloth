using System;
using System.Collections.Generic;
using System.Text;
using RentACloth.Data.Models.Enums;

namespace RentACloth.Data.Models
{
    public class Shoe:Product
    {
        public int Id { get; set; }
        public string Size { get; set; }
    }
}
