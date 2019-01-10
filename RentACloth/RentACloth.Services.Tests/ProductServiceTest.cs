using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RentACloth.Data;
using RentACloth.Data.Models;
using Xunit;

namespace RentACloth.Services.Tests
{
    [Collection("Test")]

    public class ProductServiceTest
    {
        [Fact]
        public void AddProductShouldAddProduct()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "AddProduct_Products_Database")
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<Product>(dbContext);
            var childCategoryRepository = new DbRepository<ChildCategory>(dbContext);
            var productService = new ProductService(repository, childCategoryRepository, dbContext);

            var product = new Product { Name = "Sneakers" };
            productService.AddProduct(product);

            var products = dbContext.Products.ToList();

            Assert.Single(products);
            Assert.Equal(product.Name, products.First().Name);
        }

        [Fact]
        public void EditProductShouldEditProduct()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "EditProduct_Products_Database")
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<Product>(dbContext);
            var childCategoryRepository = new DbRepository<ChildCategory>(dbContext);
            var productService = new ProductService(repository, childCategoryRepository, dbContext);

            var product = new Product
            {
                Name = "Sneakers",
                BrandName = "Armani",
                CategoryName = "Shoes",
                Price = 20
            };

            dbContext.Products.Add(product);
            repository.SaveChanges();

            product.Name = "Dress";
            product.BrandName = "PP";
            product.CategoryName = "Clothes";
            product.Price = 23;
            productService.EditProduct(product);

            var editProduct = dbContext.Products.FirstOrDefault(x => x.Name == product.Name);

            Assert.Equal(product.Name, editProduct.Name);
            Assert.Equal(product.Price, editProduct.Price);
            Assert.Equal(product.BrandName, editProduct.BrandName);
            Assert.Equal(product.CategoryName, editProduct.CategoryName);
        }

        [Fact]
        public void RemoveProductShouldRemoveProduct()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "DeleteProduct_Products_Database")
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<Product>(dbContext);
            var childCategoryRepository = new DbRepository<ChildCategory>(dbContext);
            var productService = new ProductService(repository, childCategoryRepository, dbContext);

            var product = new Product
            {
                Name = "Sneakers",
                BrandName = "Armani",
                CategoryName = "Shoes",
                Price = 20
            };
            dbContext.Products.Add(product);
            repository.SaveChanges();

            productService.RemoveProduct(product.Id);

            var productDelete = dbContext.Products.FirstOrDefault();

            Assert.Null(productDelete);
        }

        [Fact]
        public void GetProductShoudReturnProduct()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "GetProduct_Products_Database")
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<Product>(dbContext);
            var childCategoryRepository = new DbRepository<ChildCategory>(dbContext);
            var productService = new ProductService(repository, childCategoryRepository, dbContext);
            var category = new Category() { Name = "Shoes" };
            var childCategory = new ChildCategory { Name = "Armani's shoes", Category = category };
            dbContext.ChildCategories.Add(childCategory);
            dbContext.SaveChanges();

            dbContext.Products.AddRange(new List<Product>
            {
                new Product { Name = "Sneakers", ChildCategory = childCategory },
                new Product { Name = "Dress", ChildCategory = childCategory },
                new Product { Name = "Jeans", ChildCategory = childCategory }
            });

            repository.SaveChanges();

            var productId = dbContext.Products.FirstOrDefault(x => x.Name == "Sneakers").Id;
            var product = productService.GetProduct(productId);

            Assert.Equal("Sneakers", product.Name);
        }

        [Fact]
        public void GetProductByChildCategoryShouldReturnProductByThatCategory()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "GetProductByChildCategoryId_Products_Database")
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<Product>(dbContext);
            var childCategoryRepository = new DbRepository<ChildCategory>(dbContext);
            var productService = new ProductService(repository, childCategoryRepository, dbContext);
            var category = new Category() { Name = "Shoes" };
            var childCategory = new ChildCategory { Name = "Armani's shoes", Category = category };
            dbContext.ChildCategories.Add(childCategory);
            dbContext.SaveChanges();

            dbContext.Products.AddRange(new List<Product>
            {
                new Product { Name = "Sneakers", ChildCategory = childCategory },
                new Product { Name = "Dress", ChildCategory = childCategory },
                new Product { Name = "Jeans", ChildCategory = childCategory }
            });

            repository.SaveChanges();

            var products = productService.GetProductsByCategory(childCategory.Id);

            Assert.Equal(3, products.Count());

        }

        [Fact]
        public void GetAllProductsShouldReturnAllProducts()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "GetAllProducts_Products_Database")
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<Product>(dbContext);
            var childCategoryRepository = new DbRepository<ChildCategory>(dbContext);
            var productService = new ProductService(repository, childCategoryRepository, dbContext);
            var category = new Category() { Name = "Shoes" };
            var childCategory = new ChildCategory { Name = "Armani's shoes", Category = category };
            dbContext.ChildCategories.Add(childCategory);
            dbContext.SaveChanges();

            dbContext.Products.AddRange(new List<Product>
            {
                new Product { Name = "Sneakers", ChildCategory = childCategory },
                new Product { Name = "Dress", ChildCategory = childCategory },
                new Product { Name = "Jeans", ChildCategory = childCategory }
            });

            repository.SaveChanges();

            var products = productService.GetAllProducts();

            Assert.Equal(3, products.Count());

        }

        [Fact]
        public void GetChildCategoriesShouldReturnAllChildCategories()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "GetAllChildCategories_Products_Database")
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<Product>(dbContext);
            var childCategoryRepository = new DbRepository<ChildCategory>(dbContext);
            var productService = new ProductService(repository, childCategoryRepository, dbContext);
            var category = new Category() { Name = "Shoes" };
            var childCategory = new ChildCategory { Name = "Armani's shoes", Category = category };
            dbContext.ChildCategories.Add(childCategory);
            dbContext.SaveChanges();

            dbContext.Products.AddRange(new List<Product>
            {
                new Product { Name = "Sneakers", ChildCategory = childCategory },
                new Product { Name = "Dress", ChildCategory = childCategory },
                new Product { Name = "Jeans", ChildCategory = childCategory }
            });

            repository.SaveChanges();

            var childCategories = productService.GetChildCategories();

            Assert.Single(childCategories);
        }
    }
}
