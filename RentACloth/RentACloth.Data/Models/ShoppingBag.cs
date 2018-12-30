using System.Collections.Generic;

namespace RentACloth.Data.Models
{
    public class ShoppingBag
    {
        public int Id { get; set; }
        public virtual RentAClothUser RentAClothUser { get; set; }
        public virtual ICollection<ShoppingBagProduct> ShoppingBagProducts { get; set; } = new HashSet<ShoppingBagProduct>();
    }
}
