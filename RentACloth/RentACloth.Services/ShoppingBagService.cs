using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RentACloth.Common;
using RentACloth.Data;
using RentACloth.Data.Models;
using RentACloth.Services.Contracts;


namespace RentACloth.Services
{
    public class ShoppingBagService:IShoppingBagService
    {
        private readonly IRepository<ShoppingBag> shoppingBagRepository;
        private readonly IRepository<ShoppingBagProduct> shoppingBagProductRepository;
        private readonly RentAClothContext db;

        private readonly IProductService productService;
        private readonly IUserService userService;

        private const int DefaultQuantity = 1;


        public ShoppingBagService(IRepository<ShoppingBag> shoppingBagRepository, IRepository<ShoppingBagProduct> shoppingBagProductRepository, RentAClothContext db, IProductService productService, IUserService userService)
        {
            this.shoppingBagRepository = shoppingBagRepository;
            this.shoppingBagProductRepository = shoppingBagProductRepository;
            this.db = db;
            this.productService = productService;
            this.userService = userService;
        }

        public void AddProduct(int productId, string username, int? quantity = null)
        {
            var product = this.productService.GetProduct(productId);
            var user = this.userService.GetUserByUsername(username);

            if (product == null || user == null)
            {
                return;
            }

            var shoppingBagProduct = GetShoppingBagProduct(productId, user.ShoppingBagId);

            if (shoppingBagProduct!=null)
            {
                return;
            }

            shoppingBagProduct = new ShoppingBagProduct()
            {
                Product = product,
                Quantity = quantity == null ? DefaultQuantity : quantity.Value,
                ShoppingBagId = user.ShoppingBagId
            };

            this.db.ShoppingBagProducts.Add(shoppingBagProduct);
            this.shoppingBagProductRepository.SaveChanges();
        }

        

        public void EditProduct(int productId, string username, int quantity)
        {
            var product = this.productService.GetProduct(productId);
            var user = this.userService.GetUserByUsername(username);

            if (product == null || user == null)
            {
                return;
            }
            var shoppingBagProduct = GetShoppingBagProduct(productId, user.ShoppingBagId);
            if (shoppingBagProduct == null)
            {
                return;
            }

            shoppingBagProduct.Quantity = quantity;

            this.db.ShoppingBagProducts.Update(shoppingBagProduct);
            this.shoppingBagProductRepository.SaveChanges();
        }

        public ICollection<ShoppingBagProduct> GetAllShoppingBagProducts(string username)
        {
            var user = this.userService.GetUserByUsername(username);

            if (user == null)
            {
                return null;
            }

            return this.shoppingBagProductRepository.All().Include(x=>x.Product)
                .Where(x => x.ShoppingBag.RentAClothUser.UserName == username).ToList();
        }

        public void DeleteProduct(int id, string username)
        {
            var product = this.productService.GetProduct(id);
            var user = this.userService.GetUserByUsername(username);

            if (product == null || user == null)
            {
                return;
            }

            var shoppingBag = GetShoppingBagProduct(product.Id, user.ShoppingBagId);

            this.db.ShoppingBagProducts.Remove(shoppingBag);
            this.shoppingBagProductRepository.SaveChanges();
        }

        public void DeleteAllProduct(string username)
        {
            var user = this.userService.GetUserByUsername(username);

            if (user == null)
            {
                return;
            }

            var shoppingBagProducts = this.shoppingBagProductRepository.All()
                .Where(x => x.ShoppingBagId == user.ShoppingBagId);

            this.db.ShoppingBagProducts.RemoveRange(shoppingBagProducts);

            //TODO:Potential problem
            this.shoppingBagProductRepository.SaveChanges();
        }

        public bool AnyProducts(string username)
        {
            return this.shoppingBagProductRepository.All().Any(x => x.ShoppingBag.RentAClothUser.UserName == username);
        }

        private ShoppingBagProduct GetShoppingBagProduct(int productId, int userShoppingBagId)
        {
            return this.shoppingBagProductRepository.All()
                .FirstOrDefault(x => x.ShoppingBagId == userShoppingBagId && x.ProductId == productId);
        }
    }
}
