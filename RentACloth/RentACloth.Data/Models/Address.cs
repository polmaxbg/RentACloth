using System.Collections.Generic;

namespace RentACloth.Data.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string AddressDetails { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }
        public string RentAClothUserId { get; set; }
        public virtual RentAClothUser RentAClothUser { get; set; }
        public ICollection<Order> Addresses { get; set; } = new List<Order>();
    }
}
