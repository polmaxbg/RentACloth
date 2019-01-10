using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RentACloth.Data;
using RentACloth.Data.Models.Entities;
using RentACloth.Services.Mapping;
using RentACloth.Services.Models.Home;
using Xunit;

namespace RentACloth.Services.Tests
{
    [Collection("Test")]
    public class ShoesServiceTest
    {
        public void TestInitialize()
        {
            Mapper.Reset();
            AutoMapperConfig.RegisterMappings(
                typeof(IndexProductViewModel).Assembly
            );
        }
        [Fact]
        public void GetAllShoesShouldReturnAllClothes()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "GetAllShoes_Shoes_Database")
                .Options;

            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<Shoe>(dbContext);
            var clothesService = new ShoesService(repository);
            
            TestInitialize();

            dbContext.Shoes.AddRange(new List<Shoe>()
            {
                new Shoe(){Name = "Sneakers"},
                new Shoe(){Name = "Nike"},
                new Shoe(){Name = "Addidas"}
            });
            repository.SaveChanges();

            var clothes = clothesService.AllShoes();

            Assert.Equal(3, clothes.Count());
        }
    }
}
