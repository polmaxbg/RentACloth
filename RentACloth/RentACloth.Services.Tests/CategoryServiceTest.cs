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
    public class CategoryServiceTest
    {
        [Fact]
        public void AddMainCategoryShouldCreateMainCategory()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "CreateCategory_Categories_Database")
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<Category>(dbContext);

            var categoryService = new CategoryService(repository, dbContext);

            categoryService.AddMainCategory("Shoes");
            categoryService.AddMainCategory("Watches");
            categoryService.AddMainCategory("Clothes");

            var count = dbContext.Categories.ToArray().Count();

            Assert.Equal(3, count);
        }

        [Fact]
        public void GetCategoriesShouldReturnAllMainCategories()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "GetCategory_Categories_Database")
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<Category>(dbContext);

            var categoryService = new CategoryService(repository, dbContext);

            categoryService.AddMainCategory("Shoes");
            categoryService.AddMainCategory("Watches");
            categoryService.AddMainCategory("Clothes");

            var categories = categoryService.GetCategories();

            Assert.Equal(3, categories.Count());
        }

        [Fact]
        public void GetCategoryByIdShouldReturnCategoryOnThatId()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "GetCategoryId_Categories_Database")
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<Category>(dbContext);
            var categoryService = new CategoryService(repository, dbContext);


            categoryService.AddMainCategory("Watches");
            categoryService.AddMainCategory("Clothes");

            var firstCategoryId = repository.All().FirstOrDefault().Id;
            var firstCategoryName = repository.All().FirstOrDefault().Name;

            var category = categoryService.GetCategoryById(firstCategoryId);

            Assert.Equal(firstCategoryId, category.Id);
            Assert.Equal(firstCategoryName, category.Name);
        }

        [Fact]
        public void EditCategoryShouldReturnTrueAndEditCategory()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "EditCategory_Categories_Database")
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<Category>(dbContext);
            var categoryService = new CategoryService(repository, dbContext);

            categoryService.AddMainCategory("Clothes");
            var categoryId = repository.All().FirstOrDefault().Id;
            var newCategoryName = "Shoes";
            var category = categoryService.GetCategoryById(categoryId);

            var editCategory = categoryService.EditCategory(categoryId, newCategoryName);

            Assert.Equal(newCategoryName, category.Name);
            Assert.True(editCategory);
        }

        [Fact]
        public void EditCategoryShouldReturnFalse()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "EditCategory_Categories_Database")
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<Category>(dbContext);
            var categoryService = new CategoryService(repository, dbContext);
            var invalidId = 123;
            var newCategoryName = "Watches";
            var editCategory = categoryService.EditCategory(invalidId, newCategoryName);
            Assert.False(editCategory);
        }


        [Fact]
        public void DeleteCategoryShouldReturnTrueAndDeleteCategory()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "DeleteCategory_Categories_Database")
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<Category>(dbContext);
            var categoryService = new CategoryService(repository, dbContext);

            categoryService.AddMainCategory("Clothes");
            var categoryId = repository.All().FirstOrDefault().Id;

            var deleteCategory = categoryService.DeleteCategory(categoryId);

            Assert.Equal(0, dbContext.Categories.Count());
            Assert.True(deleteCategory);
        }

        [Fact]
        public void DeleteCategoryShouldReturnFalse()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "DeleteCategory_Categories_Database")
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<Category>(dbContext);
            var categoryService = new CategoryService(repository, dbContext);

            var invalidId = 123;

            var deleteCategory = categoryService.DeleteCategory(invalidId);
            Assert.False(deleteCategory);

        }

        [Fact]
        public void DeleteCategoryWithExistingChildCategoryShouldReturnFalse()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "DeleteCategoryWithChildCategory_Categories_Database")
                .Options;
            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<Category>(dbContext);
            var categoryService = new CategoryService(repository, dbContext);

            categoryService.AddMainCategory("Clothes");
            var category = repository.All().FirstOrDefault().ChildCategories = new List<ChildCategory>
                {new ChildCategory {Name = "Armani's shoes"}};

            repository.SaveChanges();
            var categoryId = repository.All().FirstOrDefault().Id;
            var deleteCategory = categoryService.DeleteCategory(categoryId);
            Assert.False(deleteCategory);

        }
    }
}