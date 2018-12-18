using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RentACloth.Common;
using RentACloth.Data.Models;
using RentACloth.Services.Contracts;
using RentACloth.Services.Mapping;

namespace RentACloth.Services
{
    public class ProductService:IProductService
    {
        private readonly IRepository<Product> productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }
        public TViewModel GetProductById<TViewModel>(int id)
        {
            var product = this.productRepository.All().Where(x => x.Id == id).To<TViewModel>().FirstOrDefault();
            return product;
        }
    }
}
