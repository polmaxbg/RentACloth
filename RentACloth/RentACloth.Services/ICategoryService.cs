using System;
using System.Collections.Generic;
using System.Text;
using RentACloth.Services.Models.Categories;

namespace RentACloth.Services
{
    public interface ICategoryService
    {
        IEnumerable<CategoryIdAndNameViewModel> GetAll();
    }
}
