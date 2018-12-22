using System;
using System.Collections.Generic;
using System.Text;
using RentACloth.Data.Models;

namespace RentACloth.Services.Contracts
{
    public interface IUserService
    {
        RentAClothUser GetUserByUsername(string username);
    }
}
