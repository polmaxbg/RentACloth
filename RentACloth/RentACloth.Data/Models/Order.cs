using System;
using System.Collections.Generic;
using System.Text;

namespace RentACloth.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? EstimatedDeliveryDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string PhoneNumber { get; set; }
        public string Recepient { get; set; }

        public string UserId { get; set; }
        public virtual RentAClothUser User { get; set; }

        public int? DeliveryAddressId { get; set; }
        public virtual Address DeliveryAddress { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; } = new HashSet<OrderProduct>();
    }
}
