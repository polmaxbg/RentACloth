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
    }
}
