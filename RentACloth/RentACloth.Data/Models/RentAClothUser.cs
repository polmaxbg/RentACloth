using Microsoft.AspNetCore.Identity;

namespace RentACloth.Data.Models
{
    // Add profile data for application users by adding properties to the RentAClothUser class
    public class RentAClothUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
