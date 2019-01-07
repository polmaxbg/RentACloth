using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACloth.Models.ShoppingBag;
using RentACloth.Services.Contracts;

namespace RentACloth.Controllers
{
    public class ShoppingBagController : BaseController
    {
        private readonly IShoppingBagService shoppingBagService;
        private readonly IProductService productService;


        public ShoppingBagController(IShoppingBagService shoppingBagService, IProductService productService)
        {
            this.shoppingBagService = shoppingBagService;
            this.productService = productService;
        }

        [Authorize]
        public IActionResult Index()
        {
            var shoppingBagProducts = this.shoppingBagService.GetAllShoppingBagProducts(this.User.Identity.Name);

            var viewModel = shoppingBagProducts.Select(x => new ShoppingBagProductsViewModel()
            {
                Id = x.ProductId,
                Name = x.Product.Name,
                Price = x.Product.Price,
                Quantity = x.Quantity,
                TotalPrice = x.Quantity * x.Product.Price,
                ImageUrl = x.Product.ImageUrl
            });


            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Add(int id)
        {
            this.shoppingBagService.AddProduct(id, this.User.Identity.Name);
            return this.RedirectToAction(nameof(Index));
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            this.shoppingBagService.DeleteProduct(id, this.User.Identity.Name);
            return this.RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id, int quantity)
        {
            this.shoppingBagService.EditProduct(id, this.User.Identity.Name, quantity);
            return this.RedirectToAction(nameof(Index));
        }


    }
}
