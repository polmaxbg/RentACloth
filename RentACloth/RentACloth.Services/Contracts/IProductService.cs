using System;
using System.Collections.Generic;
using System.Text;

namespace RentACloth.Services.Contracts
{
    public interface IProductService
    {
        TViewModel GetProductById<TViewModel>(int id);
    }
}
