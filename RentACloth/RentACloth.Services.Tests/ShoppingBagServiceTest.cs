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
    [Collection("Test")]

    public class ShoppingBagServiceTest
    {
        [Fact]
        public void AddProductShouldAddProductToShoppingBag()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "AddProductInShoppingBag_ShoppingBag_Database")
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<ShoppingBag>(dbContext);
            var shoppingBagProductsRepository = new DbRepository<ShoppingBagProduct>(dbContext);
            var username = "viktor@gmail.com";
            var user = new RentAClothUser() { UserName = username, ShoppingBag = new ShoppingBag() };
            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            var userService = new Mock<IUserService>();
            userService.Setup(r => r.GetUserByUsername(username))
                .Returns(dbContext.Users.FirstOrDefault(x => x.UserName == username));

            var productId = 1;
            var productService = new Mock<IProductService>();
            productService.Setup(p => p.GetProduct(productId))
                .Returns(new Product { Name = "Sneakers" });

            var shoppingBagService = new ShoppingBagService(repository,shoppingBagProductsRepository,dbContext,productService.Object,userService.Object);

            shoppingBagService.AddProduct(productId, username);

            var shoppingBagProducts = dbContext.ShoppingBagProducts.ToList();

            Assert.Single(shoppingBagProducts);
            Assert.Equal(user.ShoppingBagId, shoppingBagProducts.First().ShoppingBagId);
        }

        [Fact]
        public void AddProductWithInvalidUserShouldDoNothing()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "AddProductInShoppingBagWithInvalidUser_ShoppingBag_Database")
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<ShoppingBag>(dbContext);
            var shoppingBagProductsRepository = new DbRepository<ShoppingBagProduct>(dbContext);
            var username = "viktor@gmail.com";
            RentAClothUser user = null;

            var userService = new Mock<IUserService>();
            userService.Setup(r => r.GetUserByUsername(username))
                .Returns(dbContext.Users.FirstOrDefault(x => x.UserName == username));

            var productId = 1;
            var productService = new Mock<IProductService>();
            productService.Setup(p => p.GetProduct(productId))
                .Returns(new Product { Name = "Sneakers" });

            var shoppingBagService = new ShoppingBagService(repository, shoppingBagProductsRepository, dbContext, productService.Object, userService.Object);
            shoppingBagService.AddProduct(productId, username);

            var shoppingBagProducts = dbContext.ShoppingBagProducts.ToList();

            Assert.Empty(shoppingBagProducts);
        }

        [Fact]
        public void AddProductWithInvalidProductShouldDoNothing()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "AddProductInShoppingBagWithInvalidProduct_ShoppingBag_Database")
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<ShoppingBag>(dbContext);
            var shoppingBagProductsRepository = new DbRepository<ShoppingBagProduct>(dbContext);
            var username = "viktor@gmail.com";

            var user = new RentAClothUser() { UserName = username, ShoppingBag = new ShoppingBag() };
            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            var userService = new Mock<IUserService>();
            userService.Setup(r => r.GetUserByUsername(username))
                .Returns(dbContext.Users.FirstOrDefault(x => x.UserName == username));

            var productId = 1;
            Product product = null;
            var productService = new Mock<IProductService>();
            productService.Setup(p => p.GetProduct(productId))
                .Returns(product);

            var shoppingBagService = new ShoppingBagService(repository, shoppingBagProductsRepository, dbContext, productService.Object, userService.Object);
            shoppingBagService.AddProduct(productId, username);

            var shoppingBagProducts = dbContext.ShoppingBagProducts.ToList();

            Assert.Empty(shoppingBagProducts);
        }

        [Fact]
        public void AddProductWithSameProductInShoppingBagShouldDoNothing()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "AddSameProductInShoppingBag_Shopping_Database").EnableSensitiveDataLogging()
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<ShoppingBag>(dbContext);
            var shoppingBagProductsRepository = new DbRepository<ShoppingBagProduct>(dbContext);
            var username = "viktor@gmail.com";
            var user = new RentAClothUser() { UserName = username, ShoppingBag = new ShoppingBag() };
            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            var userService = new Mock<IUserService>();
            userService.Setup(r => r.GetUserByUsername(username))
                .Returns(dbContext.Users.FirstOrDefault(x => x.UserName == username));

            var productId = 2;
            var productService = new Mock<IProductService>();
            productService.Setup(p => p.GetProduct(productId))
                .Returns(new Product { Name = "Armani" });

            var shoppingBagService = new ShoppingBagService(repository, shoppingBagProductsRepository, dbContext, productService.Object, userService.Object);

            shoppingBagService.AddProduct(productId, username);
            shoppingBagService.AddProduct(productId, username);

            var shoppingBagProducts = dbContext.ShoppingBagProducts.ToList();

            Assert.Single(shoppingBagProducts);
        }


        [Theory]
        [InlineData(null, 1)]
        [InlineData(3, 3)]
        public void AddProductInShoppingBagShouldAddDefaultOrSubmittedProductQuantity(int? quantity,
            int exprectedQuantity)
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: $"AddProductInShoppingBagWithQuantity_{exprectedQuantity}_Database")
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<ShoppingBag>(dbContext);
            var shoppingBagProductsRepository = new DbRepository<ShoppingBagProduct>(dbContext);
            var user = new RentAClothUser() { UserName = "viktor@gmail.com", ShoppingBag = new ShoppingBag() };
            dbContext.Users.Add(user);

            var product = new Product { Name = "Sneaker" };
            dbContext.Products.Add(product);
            dbContext.SaveChanges();

            var userService = new Mock<IUserService>();
            userService.Setup(r => r.GetUserByUsername(user.UserName))
                .Returns(user);

            var productService = new Mock<IProductService>();
            productService.Setup(p => p.GetProduct(product.Id))
                .Returns(product);

            var shoppingBagService = new ShoppingBagService(repository, shoppingBagProductsRepository, dbContext, productService.Object, userService.Object);

            shoppingBagService.AddProduct(product.Id,user.UserName,quantity);

            var shoppingBagProducts = dbContext.ShoppingBagProducts.ToList();

            Assert.Equal(exprectedQuantity, shoppingBagProducts.First().Quantity);
        }


        [Theory]
        [InlineData(2, 2)]
        [InlineData(-2, 2)]
        [InlineData(10, 10)]
        public void EditProductShouldEditProductQuantity(int quantity, int expectedQuantity)
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "EditProductQuantityInShoppingBag_Database")
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<ShoppingBag>(dbContext);
            var shoppingBagProductsRepository = new DbRepository<ShoppingBagProduct>(dbContext);
            var product = new Product { Name = "Sneakers" };
            dbContext.Products.AddRange(product);

            var shoppingBag = new ShoppingBag()
            {
                ShoppingBagProducts = new List<ShoppingBagProduct>
                {
                    new ShoppingBagProduct() { Product = product, Quantity = 2 },
                }
            };

            var username = "viktor@gmail.com";
            var user = new RentAClothUser()
            {
                UserName = username,
                ShoppingBag = shoppingBag
            };
            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            var userService = new Mock<IUserService>();
            userService.Setup(r => r.GetUserByUsername(username))
                .Returns(user);

            var productService = new Mock<IProductService>();
            productService.Setup(p => p.GetProduct(product.Id))
                .Returns(product);

            var shoppingBagService = new ShoppingBagService(repository, shoppingBagProductsRepository, dbContext, productService.Object, userService.Object);

            shoppingBagService.EditProduct(product.Id,username,quantity);

            var shoppingBagProduct = dbContext.ShoppingBagProducts
                .FirstOrDefault(x => x.ProductId == product.Id
                                     && x.ShoppingBagId == user.ShoppingBagId);

            Assert.Equal(expectedQuantity, shoppingBagProduct.Quantity);

        }

        [Fact]
        public void GetAllShouldReturnAllProductForThisUser()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: $"GetAllShoppingBagProducts_Database")
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<ShoppingBag>(dbContext);
            var shoppingBagProductsRepository = new DbRepository<ShoppingBagProduct>(dbContext);
            var products = new List<Product>
            {
                new Product { Name = "Sneakers" },
                new Product { Name = "Jeans" },
                new Product { Name = "T-Shirt" }
            };
            dbContext.Products.AddRange(products);

            var shoppingBagProducts = new List<ShoppingBagProduct>
            {
                new ShoppingBagProduct() { Product = products.First() },
                new ShoppingBagProduct() { Product = products.Last() },
            };
            var user = new RentAClothUser()
            {
                UserName = "viktor@gmail.com",
                ShoppingBag = new ShoppingBag()
                {
                    ShoppingBagProducts = shoppingBagProducts
                }
            };
            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            var userService = new Mock<IUserService>();
            userService.Setup(r => r.GetUserByUsername(user.UserName))
                .Returns(user);

            var productService = new Mock<IProductService>();

            var shoppingBagService = new ShoppingBagService(repository, shoppingBagProductsRepository, dbContext, productService.Object, userService.Object);

            var shoppingBagProduct = shoppingBagService.GetAllShoppingBagProducts(user.UserName);

            Assert.Equal(2, shoppingBagProduct.Count());
        }

        [Fact]
        public void DeleteAllProductsShouldDeleteAllProducts()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "DeleteAllShoppingBagProducts_Database")
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<ShoppingBag>(dbContext);
            var shoppingBagProductsRepository = new DbRepository<ShoppingBagProduct>(dbContext);
            var products = new List<Product>
            {
                new Product { Name = "Sneakers" },
                new Product { Name = "Jeans" },
                new Product { Name = "T-Shirt" }
            };
            dbContext.Products.AddRange(products);

            var shoppingBagProducts = new List<ShoppingBagProduct>
            {
                new ShoppingBagProduct() { Product = products.First() },
                new ShoppingBagProduct() { Product = products.Last() },
            };
            var user = new RentAClothUser()
            {
                UserName = "viktor@gmail.com",
                ShoppingBag = new ShoppingBag()
                {
                    ShoppingBagProducts = shoppingBagProducts
                }
            };
            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            var userService = new Mock<IUserService>();
            userService.Setup(r => r.GetUserByUsername(user.UserName))
                .Returns(user);

            var productService = new Mock<IProductService>();

            var shoppingBagService = new ShoppingBagService(repository, shoppingBagProductsRepository, dbContext, productService.Object, userService.Object);

            shoppingBagService.DeleteAllProduct(user.UserName);

            var userShoppingBag = dbContext.ShoppingBagProducts.Where(x => x.ShoppingBagId == user.ShoppingBagId);

            Assert.Empty(userShoppingBag);
        }

        [Fact]
        public void DeleteProductShoulDeleteProduct()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "DeleteShoppingBagProduct_Database")
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<ShoppingBag>(dbContext);
            var shoppingBagProductsRepository = new DbRepository<ShoppingBagProduct>(dbContext);
            var products = new List<Product>
            {
                new Product { Name = "Sneakers" },
                new Product { Name = "Jeans" },
                new Product { Name = "T-Shirt" }
            };
            dbContext.Products.AddRange(products);

            var shoppingBagProducts = new List<ShoppingBagProduct>
            {
                new ShoppingBagProduct() { Product = products.First() },
                new ShoppingBagProduct() { Product = products.Last() },
            };
            var user = new RentAClothUser()
            {
                UserName = "viktor@gmail.com",
                ShoppingBag = new ShoppingBag()
                {
                    ShoppingBagProducts = shoppingBagProducts
                }
            };
            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            var userService = new Mock<IUserService>();
            userService.Setup(r => r.GetUserByUsername(user.UserName))
                .Returns(user);

            var productToDelete = products.First();
            var productService = new Mock<IProductService>();
            productService.Setup(p => p.GetProduct(productToDelete.Id))
                .Returns(productToDelete);

            var shoppingBagService = new ShoppingBagService(repository, shoppingBagProductsRepository, dbContext, productService.Object, userService.Object);

            shoppingBagService.DeleteProduct(productToDelete.Id,user.UserName);

            var shoppingBagProduct = dbContext.ShoppingBagProducts.Where(x => x.ShoppingBagId == user.ShoppingBagId && x.ProductId == productToDelete.Id).ToList();

            Assert.Empty(shoppingBagProduct);
        }

        [Fact]
        public void AnyProductShouldReturnTrueIfThereAreSomeProducts()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "АnyProducts_Database")
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<ShoppingBag>(dbContext);
            var shoppingBagProductsRepository = new DbRepository<ShoppingBagProduct>(dbContext);
            var user = new RentAClothUser() { UserName = "viktor@gmail.com", ShoppingBag = new ShoppingBag() };
            dbContext.Users.Add(user);

            var product = new Product { Name = "Sneakers" };
            dbContext.Products.Add(product);
            dbContext.SaveChanges();

            var userService = new Mock<IUserService>();
            userService.Setup(r => r.GetUserByUsername(user.UserName))
                .Returns(user);

            var productService = new Mock<IProductService>();
            productService.Setup(p => p.GetProduct(product.Id))
                .Returns(product);

            var shoppingBagService = new ShoppingBagService(repository, shoppingBagProductsRepository, dbContext,
                productService.Object, userService.Object);

            shoppingBagService.AddProduct(product.Id, user.UserName);

            var anyProducts = shoppingBagService.AnyProducts(user.UserName);

            Assert.True(anyProducts);
        }

        [Fact]
        public void AnyProductShouldReturnFalse()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "АnyProductsFalse_Database")
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<ShoppingBag>(dbContext);
            var shoppingBagProductsRepository = new DbRepository<ShoppingBagProduct>(dbContext);
            var user = new RentAClothUser() { UserName = "viktor@gmail.com", ShoppingBag = new ShoppingBag() };
            dbContext.Users.Add(user);

            var product = new Product { Name = "Sneakers" };
            dbContext.Products.Add(product);
            dbContext.SaveChanges();

            var userService = new Mock<IUserService>();
            userService.Setup(r => r.GetUserByUsername(user.UserName))
                .Returns(user);

            var productService = new Mock<IProductService>();

            var shoppingBagService = new ShoppingBagService(repository, shoppingBagProductsRepository, dbContext,
                productService.Object, userService.Object);

            shoppingBagService.AddProduct(product.Id, user.UserName);

            var anyProducts = shoppingBagService.AnyProducts(user.UserName);

            Assert.False(anyProducts);
        }
    }
}
