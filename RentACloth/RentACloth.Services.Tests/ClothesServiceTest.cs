using System.Collections.Generic;
using System.Linq;
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
    public class ClothesServiceTest
    {
        public void TestInitialize()
        {
            Mapper.Reset();
            AutoMapperConfig.RegisterMappings(
                typeof(IndexProductViewModel).Assembly
            );
        }
        [Fact]
        public void GetAllClothesShouldReturnAllClothes()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "GetAllClothes_Clothes_Database")
                .Options;

            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<Cloth>(dbContext);
            var clothesService = new ClothesService(repository);

            TestInitialize();

            dbContext.Cloths.AddRange(new List<Cloth>()
            {
                new Cloth(){Name = "Dress"},
                new Cloth(){Name = "Something"},
                new Cloth(){Name = "Jeans"}
            });
            repository.SaveChanges();

            var clothes = clothesService.AllClothes();

            Assert.Equal(3,clothes.Count());
        }
    }
}
