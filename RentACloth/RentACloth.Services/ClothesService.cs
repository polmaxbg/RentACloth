using System;
using System.Collections.Generic;
using System.Text;
using RentACloth.Common;
using RentACloth.Data.Models.Entities;
using RentACloth.Services.Contracts;
using RentACloth.Services.Mapping;
using RentACloth.Services.Models.Home;

namespace RentACloth.Services
{
    public class ClothesService:IClothService
    {
        private readonly IRepository<Cloth> clothesRepository;

        public ClothesService(IRepository<Cloth> productsRepository)
        {
            this.clothesRepository = productsRepository;
        }

        public IEnumerable<IndexProductViewModel> AllClothes()
        {
            return this.clothesRepository.All().To<IndexProductViewModel>();
        }
    }
}
