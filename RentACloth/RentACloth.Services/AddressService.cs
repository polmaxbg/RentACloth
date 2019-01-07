using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RentACloth.Common;
using RentACloth.Data;
using RentACloth.Data.Models;
using RentACloth.Services.Contracts;
using RentACloth.Services.Mapping;
using RentACloth.Services.Models.Addresses;

namespace RentACloth.Services
{
    public class AddressService:IAddressService
    {
        private readonly IUserService userService;
        private readonly IRepository<Address> addressRepository;
        private readonly RentAClothContext db;

        public AddressService(IUserService userService, IRepository<Address> addressRepository, RentAClothContext db)
        {
            this.userService = userService;
            this.addressRepository = addressRepository;
            this.db = db;
        }


        public Address CreateAddress(string deliveryAddress, string city, string addressDetails)
        {
            var address = new Address()
            {
                City = city,
                Street = deliveryAddress,
                AddressDetails = addressDetails
            };

            this.addressRepository.Add(address);
            this.addressRepository.SaveChanges();

            return address;
        }

        public void AddAddressToUser(string username, Address address)
        {
            //var user = this.userService.GetUserByUsername(username);
            //user.Addresses.Add(address);

            this.addressRepository.SaveChanges();
        }

        public IEnumerable<IndexAddressViewModel> GetAllAddressByUser(string username)
        {
            return this.db.Addresses.Include(x => x.City).Where(x => x.RentAClothUser.UserName == username).To<IndexAddressViewModel>();
        }
    }
}
