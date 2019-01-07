using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACloth.Models.ShoppingBag;
using RentACloth.Services.Contracts;

namespace RentACloth.Components
{
    public class ShoppingBagComponent:ViewComponent
    {
        private IShoppingBagService shoppingBagService;

        public ShoppingBagComponent(IShoppingBagService shoppingBagService)
        {
            this.shoppingBagService = shoppingBagService;
        }

        [Authorize]
        public IViewComponentResult Invoke()
        {
            var shoppingBagProducts = this.shoppingBagService.GetAllShoppingBagProducts(this.User.Identity.Name);

            var shoppingBagViewModel = shoppingBagProducts.Select(x=>new ShoppingBagProductsViewModel()
            {
                Id = x.ProductId,
                ImageUrl = x.Product.ImageUrl,
                Name = x.Product.Name,
                Price = x.Product.Price,
                Quantity = x.Quantity,
                TotalPrice = x.Quantity*x.Product.Price
            }).ToList();

            return this.View(shoppingBagViewModel);
        }
    }
}
