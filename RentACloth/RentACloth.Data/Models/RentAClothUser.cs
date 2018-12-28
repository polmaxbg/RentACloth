using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace RentACloth.Data.Models
{
    // Add profile data for application users by adding properties to the RentAClothUser class
    public class RentAClothUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ShoppingBagId { get; set; }
        public virtual ShoppingBag ShoppingBag { get; set; }

        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public ICollection<Address> Addresses { get; set; } = new HashSet<Address>();
    }
}
