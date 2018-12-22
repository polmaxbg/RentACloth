using System.Collections.Generic;

namespace RentACloth.Data.Models
{
    public class ShoppingBag
    {
        public int Id { get; set; }
        public RentAClothUser RentAClothUser { get; set; }
        public ICollection<ShoppingBagProduct> ShoppingBagProducts { get; set; } = new HashSet<ShoppingBagProduct>();
    }
}
