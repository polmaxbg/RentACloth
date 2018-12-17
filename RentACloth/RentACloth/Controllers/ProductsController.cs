using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentACloth.Data.Models;

using RentACloth.Services.Contracts;
using RentACloth.Services.Mapping;
using RentACloth.Services.Models.Home;

namespace RentACloth.Controllers
{
    public class ProductsController:BaseController
    {
        private readonly IShoesService shoesService;
        private readonly IClothService clothesService;
        private readonly IAccessoriesService accessoriesService;
        private readonly IWatchesService watchesService
            ;


        public ProductsController(IShoesService shoesService, IClothService clothesService, IAccessoriesService accessories, IWatchesService watchesService)
        {
            this.shoesService = shoesService;
            this.clothesService = clothesService;
            this.accessoriesService = accessories;
            this.watchesService = watchesService;
        }

        public IActionResult AllShoes()
        {
            var shoes = this.shoesService.AllShoes();
            
            var viewModel = new IndexViewModel
            {
                Products = shoes
            };
            return this.View(viewModel);
        }

        public IActionResult AllClothes()
        {
            var clothes = this.clothesService.AllClothes();

            var viewModel = new IndexViewModel
            {
                Products = clothes
            };
            return this.View(viewModel);
        }

        public IActionResult AllAccessories()
        {
            var clothes = this.accessoriesService.AllAccessories();

            var viewModel = new IndexViewModel
            {
                Products = clothes
            };
            return this.View(viewModel);
        }

        public IActionResult AllWatches()
        {
            var clothes = this.watchesService.AllWatches();

            var viewModel = new IndexViewModel
            {
                Products = clothes
            };
            return this.View(viewModel);
        }
    }
}
