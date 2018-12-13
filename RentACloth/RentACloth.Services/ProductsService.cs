using System;
using System.Collections.Generic;
using System.Text;
using RentACloth.Common;
using RentACloth.Data.Models;
using RentACloth.Services.Contracts;
using RentACloth.Services.Mapping;

namespace RentACloth.Services
{
    public class ProductsService:IProductsService
    {
        private readonly IRepository<Product> productsRepository;

        public ProductsService(IRepository<Product> productsRepository)
        {
            this.productsRepository = productsRepository;
        }
        
        public IEnumerable<IndexProductViewModel> All () => this.productsRepository.All().To<IndexProductViewModel>();
    }
}
