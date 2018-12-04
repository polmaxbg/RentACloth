using System;
using System.Collections.Generic;
using System.Text;

namespace RentACloth.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string Number { get; set; }

        public string UserId { get; set; }
        public virtual RentAClothUser User { get; set; }
    }
}
