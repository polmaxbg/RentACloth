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

    public class ChildCategoryServiceTest
    {

        [Fact]
        public void GetChildCategoriesShouldReturnAllChildCategories()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "AllChildCategories_ChildCategories_Database")
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<ChildCategory>(dbContext);
            var childCategoryService = new ChildCategoryService(repository, dbContext);

            var category = new Category() {Name = "Shoes"};
            dbContext.ChildCategories.AddRange(new List<ChildCategory>()
            {
                new ChildCategory { Name = "Armani's shoes", CategoryId = category.Id, Category = category },
                new ChildCategory { Name = "HugoBoss's shoes", CategoryId = category.Id, Category = category }
            });

            repository.SaveChanges();

            var childCategories = childCategoryService.GetChildCategories();

            var count = childCategories.Count();

            Assert.Equal(2, count);
        }

        [Fact]
        public void GetChildGategoryByIdShouldReturnChildCategory()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "GetChildCategory_ChildCategoriesById_Database")
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<ChildCategory>(dbContext);
            var childCategoryService = new ChildCategoryService(repository, dbContext);

            var category = new Category() { Name = "Shoes" };
            dbContext.ChildCategories.AddRange(new List<ChildCategory>()
            {
                new ChildCategory { Name = "Armani's shoes", Id = 3, Category = category },
                new ChildCategory { Name = "HugoBoss's shoes", Id = 4, Category = category }
            });

            repository.SaveChanges();

            var childCategories = childCategoryService.GetChildCategoryById(3);

            Assert.Equal("Armani's shoes", childCategories.Name);
        }

        [Fact]
        public void CreateChildCategoryShouldCreateChildCategory()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "CreateChildCategory_ChildCategories_Database")
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<ChildCategory>(dbContext);
            var childCategoryService = new ChildCategoryService(repository, dbContext);

            dbContext.Categories.Add(new Category() {Name = "Clothes"});
            repository.SaveChanges();

            var categoryName = "Clothes";
            var category = dbContext.Categories.FirstOrDefault(x => x.Name == categoryName);

            var childCategoryName = "Armani's shoes";
            var childCategory = childCategoryService.CreateChildCategory(childCategoryName, category.Id);

            Assert.Equal(1, dbContext.ChildCategories.Count());
            Assert.Equal(childCategoryName, childCategory.Name);
        }

        [Fact]
        public void EditChildCategoryShouldReturnTrueAndEditCategory()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "EditChildCategory_ChildCategories_Database")
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<ChildCategory>(dbContext);
            var childCategoryService = new ChildCategoryService(repository, dbContext);

            var categoryName = "Clothes";
            dbContext.Categories.Add(new Category() { Name = categoryName });
            repository.SaveChanges();

            var category = dbContext.Categories.FirstOrDefault(x => x.Name == categoryName);
            var childCategoryName = "Armani's shoes";
            var childCategory = childCategoryService.CreateChildCategory(childCategoryName, category.Id);

            var newChildCategoryName = "Armani's clothes";
            var editChildCategory =
                childCategoryService.EditChildCategory(childCategory.Id, newChildCategoryName, category.Id);

            Assert.Equal(newChildCategoryName, childCategory.Name);
            Assert.True(editChildCategory);
        }

        [Fact]
        public void EditChildCategoryShouldReturnFalse()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "EditChildCategory_ChildCategories_Database")
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<ChildCategory>(dbContext);
            var childCategoryService = new ChildCategoryService(repository, dbContext);

            var newChildCategoryName = "Armani's clothes";
            var invalidChildCategoryId = 155;
            var invalidCategoryId = 1556;
            var editChildCategory =
                childCategoryService.EditChildCategory(invalidChildCategoryId, newChildCategoryName, invalidCategoryId);

            Assert.False(editChildCategory);
        }

        [Fact]
        public void DeleteChildCategoryShouldDeleteChildCategory()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "DeleteChildCategori_ChildCategories_Database")
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<ChildCategory>(dbContext);
            var childCategoryService = new ChildCategoryService(repository, dbContext);

            var categoryName = "Clothes";
            dbContext.Categories.Add(new Category() { Name = categoryName });
            repository.SaveChanges();

            var category = dbContext.Categories.FirstOrDefault(x => x.Name == categoryName);
            var childCategoryName = "Armani's shoes";
            var childCategory = childCategoryService.CreateChildCategory(childCategoryName, category.Id);

            var deleteChildCategory = childCategoryService.DeleteChildCategory(childCategory.Id);

            Assert.Equal(0, dbContext.ChildCategories.Count());
            Assert.True(deleteChildCategory);
        }

        [Fact]
        public void DeleteChildCategoryShouldReturnFalse()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "DeleteChildCategory_ChildCategories_Database")
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<ChildCategory>(dbContext);
            var childCategoryService = new ChildCategoryService(repository, dbContext);

            var invalidChildCategoryId = 155;
            var deleteChildCategory = childCategoryService.DeleteChildCategory(invalidChildCategoryId);
            Assert.False(deleteChildCategory);

        }

        [Fact]
        public void DeleteChildCategoriesWithProductsShouldReturnFalse()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "DeleteChildCategory_ChildCategories_Database")
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<ChildCategory>(dbContext);
            var childCategoryService = new ChildCategoryService(repository, dbContext);

            var categoryName = "Clothes";
            dbContext.Categories.Add(new Category() { Name = categoryName });
            repository.SaveChanges();

            var category = dbContext.Categories.FirstOrDefault(x => x.Name == categoryName);
            var childCategoryName = "Armani's shoes";
            var childCategory = childCategoryService.CreateChildCategory(childCategoryName, category.Id);

            childCategory.Products=new List<Product>{new Product{Name = "Sneakers"}};
            repository.SaveChanges();

            var deleteChildCategory = childCategoryService.DeleteChildCategory(childCategory.Id);
            Assert.False(deleteChildCategory);
            Assert.Equal(1, dbContext.ChildCategories.Count());
        }
    }
}
