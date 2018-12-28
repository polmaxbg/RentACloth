using System;
using System.Collections.Generic;
using System.Text;
using RentACloth.Data.Models;
using RentACloth.Services.Models.Addresses;

namespace RentACloth.Services.Contracts
{
    public interface IAddressService
    {
        Address CreateAddress(string deliveryAddress, string city, string addressDetails);

        void AddAddressToUser(string username, Address address);

        IEnumerable<IndexAddressViewModel> GetAllAddressByUser(string username);
    }
}
