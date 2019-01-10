using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using RentACloth.Data;
using RentACloth.Data.Models;
using Xunit;

namespace RentACloth.Services.Tests
{
    [Collection("Test")]
    public class UserServiceTest
    {
        [Fact]
        public void GetUserByUsernameShouldReturnUser()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "GetUser_Users_Database")
                .Options;

            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<RentAClothUser>(dbContext);

            var user = new RentAClothUser()
            {
                UserName = "viktor@gmail.com",
            };
            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            var mockUserStore = new Mock<IUserStore<RentAClothUser>>();
            var userManager = new Mock<UserManager<RentAClothUser>>(mockUserStore.Object, null, null, null, null, null, null, null, null);
            userManager.Setup(m => m.FindByNameAsync(user.UserName))
                .Returns(Task.FromResult<RentAClothUser>(user));

            var usersService = new UserService(repository, userManager.Object);

            var currentUser = usersService.GetUserByUsername(user.UserName);

            Assert.Equal(currentUser.UserName, user.UserName);

        }
    }
}
