using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RentACloth.Common;
using RentACloth.Data.Models;
using RentACloth.Data.Models.Entities;
using RentACloth.Services.Contracts;
using RentACloth.Services.Mapping;
using RentACloth.Services.Models.Home;

namespace RentACloth.Services
{
    public class ShoesService:IShoesService
    {
        private readonly IRepository<Shoe> shoesRepository;

        public ShoesService(IRepository<Shoe> productsRepository)
        {
            this.shoesRepository = productsRepository;
        }

        public IEnumerable<IndexProductViewModel> AllShoes()
        {
            return this.shoesRepository.All().To<IndexProductViewModel>();
        }
    }
}
