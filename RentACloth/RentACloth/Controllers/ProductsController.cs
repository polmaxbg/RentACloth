using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentACloth.Data.Models;
using RentACloth.Models.ProductsViewModel;
using RentACloth.Services.Contracts;
using RentACloth.Services.Mapping;

namespace RentACloth.Controllers
{
    public class ProductsController:BaseController
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public IActionResult All()
        {
            var products = this.productsService.All();
            var viewModel = new IndexViewModel
            {
                Products = products
            };
            return this.View(viewModel);
        }
    }
}
