using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACloth.Models.ProductsViewModel;
using RentACloth.Services.Contracts;
using RentACloth.Services.Models.Home;

namespace RentACloth.Controllers
{
    public class ProductsController:BaseController
    {
        private readonly IShoesService shoesService;
        private readonly IClothService clothesService;
        private readonly IAccessoriesService accessoriesService;
        private readonly IWatchesService watchesService;
        private readonly IProductService productService;



        public ProductsController(IShoesService shoesService, IClothService clothesService, IAccessoriesService accessories, IWatchesService watchesService, IProductService productService)
        {
            this.shoesService = shoesService;
            this.clothesService = clothesService;
            this.accessoriesService = accessories;
            this.watchesService = watchesService;
            this.productService = productService;
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

        public IActionResult Details(int id)
        {
            var product = this.productService.GetProductById<ProductDetailsViewModel>(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult CreateProduct()
        {
            return this.View();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult CreateProduct(CreateProductViewModel model)
        {
            return this.View();
        }
    }

    public class CreateProductViewModel
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public string ProductType { get; set; }
        public string EventType { get; set; }
        public string S { get; set; }
    }
}
