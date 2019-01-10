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
    public class WatchesServiceTest
    {
        public void TestInitialize()
        {
            Mapper.Reset();
            AutoMapperConfig.RegisterMappings(
                typeof(IndexProductViewModel).Assembly
            );
        }
        [Fact]
        public void GetAllWatchesShouldReturnAllWatches()
        {
            var options = new DbContextOptionsBuilder<RentAClothContext>()
                .UseInMemoryDatabase(databaseName: "GetAllWatches_Watches_Database")
                .Options;

            var dbContext = new RentAClothContext(options);
            var repository = new DbRepository<Watch>(dbContext);
            var watchesService = new WatchesService(repository);

            TestInitialize();

            dbContext.Watches.AddRange(new List<Watch>()
            {
                new Watch(){Name = "Rolex"},
                new Watch(){Name = "Casio"}
            });
            repository.SaveChanges();

            var watches = watchesService.AllWatches();

            Assert.Equal(2, watches.Count());
        }
    }
}
