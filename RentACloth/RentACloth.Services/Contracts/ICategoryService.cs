using System.Collections.Generic;
using RentACloth.Services.Models.Categories;

namespace RentACloth.Services.Contracts
{
    public interface ICategoryService
    {
        IEnumerable<CategoryIdAndNameViewModel> GetAll();
    }
}
