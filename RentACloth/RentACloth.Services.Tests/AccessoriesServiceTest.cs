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
    public class AccessoriesServiceTest
    {
        public void TestInitialize()
        {
            Mapper.Reset();
            AutoMapperConfig.RegisterMappings(
                typeof(IndexProductViewModel).Assembly
            );
        }
        [Fact]
        public void GetAllAccessoriesShouldReturnAllAccessories()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "GetAllAccessories_Accessories_Database")
                .Options;

            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<Accessories>(dbContext);
            var accessoriesService = new AccessoriesService(repository);

            TestInitialize();

            dbContext.Accessories.AddRange(new List<Accessories>()
            {
                new Accessories(){Name = "Armani"},
                new Accessories(){Name = "HugoBoss"}
            });
            repository.SaveChanges();

            var accessories = accessoriesService.AllAccessories();

            Assert.Equal(2, accessories.Count());
        }
    }
}
