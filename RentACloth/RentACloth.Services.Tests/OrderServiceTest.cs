using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Moq;
using RentACloth.Data;
using RentACloth.Data.Models;
using RentACloth.Services.Contracts;
using Xunit;

namespace RentACloth.Services.Tests
{
    public class OrderServiceTest
    {
        [Fact]
        public void CreateOrderShouldCreteOrder()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "CreateOrder_Orders_Database")
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<Order>(dbContext);

            var shoppingBagService = new Mock<IShoppingBagService>();

            var username = "viktor@gmail.com";
            var user = new RentAClothUser { UserName = username };

            var usersService = new Mock<IUserService>();
            usersService.Setup(u => u.GetUserByUsername(username))
                .Returns(user);

            var ordersService = new OrderService(usersService.Object, shoppingBagService.Object, repository, dbContext);
            ordersService.CreateOrder(username);

            var orders = dbContext.Orders.ToList();

            Assert.Single(orders);
        }

        [Fact]
        public void GetOrderByIdShouldReturnOrder()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "CreateOrderById_Orders_Database")
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<Order>(dbContext);

            var shoppingBagService = new Mock<IShoppingBagService>();
            var user = new RentAClothUser()
            {
                UserName = "viktor@gmail.com",
                Orders = new List<Order>
                {
                    new Order { Id = 1  },
                    new Order { Id = 2  },
                    new Order { Id = 3 },
                }
            };
            dbContext.Users.Add(user);
            repository.SaveChanges();

            var usersService = new Mock<IUserService>();
            usersService.Setup(u => u.GetUserByUsername(user.UserName))
                .Returns(dbContext.Users.FirstOrDefault(x => x.UserName == user.UserName));
            var ordersService = new OrderService(usersService.Object, shoppingBagService.Object, repository, dbContext);

            var order = ordersService.GetOrderById(3);

            Assert.Equal(3, order.Id);
        }

        [Fact]
        public void GetOrderByUsernameShouldReturnOrder()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "GetOrderByUsername_Orders_Database")
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<Order>(dbContext);

            var shoppingBagService = new Mock<IShoppingBagService>();

            var user = new RentAClothUser() { UserName = "viktor@gmail.com" };
            var orders = new List<Order>
            {
                new Order {  User = user },
                new Order {  User = user },
                new Order {  User = new RentAClothUser() {UserName = "admin@gmail.com" } },
            };

            dbContext.Orders.AddRange(orders);
            dbContext.SaveChanges();

            var usersService = new Mock<IUserService>();
            usersService.Setup(u => u.GetUserByUsername(user.UserName))
                .Returns(dbContext.Users.FirstOrDefault(x => x.UserName == user.UserName));
            var ordersService = new OrderService(usersService.Object, shoppingBagService.Object, repository, dbContext);

            var ordersByUser = ordersService.GetOrderByUsername(user.UserName);

            Assert.Equal("viktor@gmail.com", ordersByUser.User.UserName);
        }

        [Fact]
        public void GetUsersOrdersShoudReturnAllOrdersByUser()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "GetAllOrdersByUsername_Orders_Database")
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<Order>(dbContext);

            var shoppingBagService = new Mock<IShoppingBagService>();

            var user = new RentAClothUser() { UserName = "viktor@gmail.com" };
            var orders = new List<Order>
            {
                new Order {  User = user },
                new Order {  User = user },
                new Order {  User = new RentAClothUser() {UserName = "admin@gmail.com" } },
            };

            dbContext.Orders.AddRange(orders);
            dbContext.SaveChanges();

            var usersService = new Mock<IUserService>();
            usersService.Setup(u => u.GetUserByUsername(user.UserName))
                .Returns(dbContext.Users.FirstOrDefault(x => x.UserName == user.UserName));
            var ordersService = new OrderService(usersService.Object, shoppingBagService.Object, repository, dbContext);

            var userOrders = ordersService.GetUserOrders(user.UserName);
            Assert.Equal(2, userOrders.Count());

        }


        [Fact]
        public void SetOrderShouldSetOrdersDetails()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "SetOrder_Orders_Database")
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<Order>(dbContext);

            var shoppingBagService = new Mock<IShoppingBagService>();
            var order = new Order();
            dbContext.Orders.Add(order);

            var address = new Address() { Street = "Iordan Iovkov" };
            dbContext.Addresses.Add(address);

            repository.SaveChanges();

            var usersService = new Mock<IUserService>();
            var ordersService = new OrderService(usersService.Object, shoppingBagService.Object, repository, dbContext);

            var recipient = "Viktor Slavchev";
            var phoneNumber = "0885924981";
            ordersService.SetOrder(order, recipient, phoneNumber, address.Id);

            Assert.Equal(recipient, order.Recepient);
            Assert.Equal(phoneNumber, order.PhoneNumber);
            Assert.Equal(address.Id, order.DeliveryAddressId);

        }

        [Fact]
        public void CompleteOrderShoudCompleteOrder()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "CompleteOrder_Orders_Database")
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<Order>(dbContext);

            var user = new RentAClothUser()
            {
                UserName = "viktor@gmail.com",
                Orders = new List<Order> { new Order() },
                ShoppingBag = new ShoppingBag()
            };

            var shoppinBagProducts = new List<ShoppingBagProduct>()
            {
                new ShoppingBagProduct()
                {
                    Product = new Product { Name = "Dress", Price = 10},
                    ShoppingBag = user.ShoppingBag,
                    Quantity = 1
                },
               new ShoppingBagProduct()
                {
                    Product = new Product { Name = "Sneakers", Price = 10},
                    ShoppingBag = user.ShoppingBag,
                    Quantity = 1
                }
            };

            dbContext.Users.Add(user);
            dbContext.ShoppingBagProducts.AddRange(shoppinBagProducts);
            repository.SaveChanges();

            var shoppingBagService = new Mock<IShoppingBagService>();
            shoppingBagService.Setup(s => s.GetAllShoppingBagProducts(user.UserName))
                .Returns(shoppinBagProducts);

            var usersService = new Mock<IUserService>();
            usersService.Setup(u => u.GetUserByUsername(user.UserName))
                .Returns(dbContext.Users.FirstOrDefault(x => x.UserName == user.UserName));

            var ordersService = new OrderService(usersService.Object, shoppingBagService.Object, repository, dbContext);

            ordersService.CompleteOrder(user.UserName);

            var order = dbContext.Orders.FirstOrDefault(x => x.User.UserName == user.UserName);
            
            Assert.Equal(2, order.OrderProducts.Count());
            Assert.Equal(20, order.TotalPrice);
        }
    }
}
