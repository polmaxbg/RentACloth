using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;
using RentACloth.Data;
using RentACloth.Data.Models;
using RentACloth.Services.Contracts;
using Xunit;

namespace RentACloth.Services.Tests
{
    public class AddressesServiceTest
    {
        [Fact]
        public void CreateAddressShouldCreateAddress()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "Address_CreateAddress_Database")
                .Options;
            var dbContext = new RentAClothContext(options);

            var repository = new DbRepository<Address>(dbContext);

            var addressService = new AddressService(null, repository, dbContext);

            addressService.CreateAddress("IordanIovkov", "Description", "Sofiya");
            addressService.CreateAddress("Street", "Description", "Varna");

            var count = dbContext.Addresses.ToArray().Count();

            Assert.Equal(2, count);
        }

        [Fact]
        public void AddAddressToUserShouldAddAddressToUser()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "Address_AddAddressToUser_Database")
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<Address>(dbContext);

            var username = "viktor@gmail.com";
            var user = new RentAClothUser { UserName = username };

            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            var userService = new Mock<IUserService>();
            userService.Setup(r => r.GetUserByUsername(username))
                .Returns(dbContext.Users.FirstOrDefault(x => x.UserName == username));

            var addressService = new AddressService(userService.Object,repository, dbContext);

            var address = new Address
            {
                Street = "Ivan Vazov",
                AddressDetails = "106",
                City = "Sofia",
                Country = "Bulgaria"
            };

            addressService.AddAddressToUser(username, address);

            var userAddress = dbContext.Users
                .FirstOrDefault(x => x.UserName == username)
                .Addresses
                .FirstOrDefault();

            Assert.Equal(address.Street, userAddress.Street);
            Assert.Equal(address.AddressDetails, userAddress.AddressDetails);
            Assert.Equal(address.Country, userAddress.Country);
            Assert.Equal(address.City, userAddress.City);
        }
    }
}
