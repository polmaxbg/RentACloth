using System;
using System.Collections.Generic;
using System.Text;
using RentACloth.Data.Models;

namespace RentACloth.Services.Contracts
{
    public interface IProductService
    {
        TViewModel GetProductById<TViewModel>(int id);
        Product GetProduct(int id);
        IEnumerable<ChildCategory> GetChildCategories();
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(int? childCategoryId);
        void AddProduct(Product product);
        void EditProduct(Product product);
        void RemoveProduct(int productId);

    }
}
