using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RentACloth.Common;
using RentACloth.Data;
using RentACloth.Data.Models;
using RentACloth.Data.Models.Enums;
using RentACloth.Services.Contracts;
using RentACloth.Services.Mapping;

namespace RentACloth.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> productRepository;
        private readonly IRepository<ChildCategory> childCategoryRepository;
        private readonly RentAClothContext db;

        public ProductService(IRepository<Product> productRepository, IRepository<ChildCategory> childCategoryRepository, RentAClothContext db)
        {
            this.productRepository = productRepository;
            this.childCategoryRepository = childCategoryRepository;
            this.db = db;
        }
        public TViewModel GetProductById<TViewModel>(int id)
        {
            var product = this.productRepository.All().Where(x => x.Id == id).To<TViewModel>().FirstOrDefault();
            return product;
        }

        public Product GetProduct(int id)
        {
            var product = this.productRepository.All().Include(x=>x.ChildCategory).FirstOrDefault(m => m.Id == id);
            return product;
        }

        public IEnumerable<ChildCategory> GetChildCategories()
        {
            return this.childCategoryRepository.All();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return this.productRepository.All().Include(x=>x.ChildCategory).ThenInclude(x=>x.Category);
        }

        public void AddProduct(Product product)
        {
            this.productRepository.Add(product);
            this.productRepository.SaveChanges();
        }

        public void EditProduct(Product product)
        {
            this.db.Products.Update(product);
            this.productRepository.SaveChanges();
        }

        public void RemoveProduct(int productId)
        {
            var product = this.productRepository.All().FirstOrDefault(x => x.Id == productId);
            if (product==null)
            {
                throw new Exception("Product not found");
            }
            this.db.Products.Remove(product);
            this.productRepository.SaveChanges();
        }
    }
}
