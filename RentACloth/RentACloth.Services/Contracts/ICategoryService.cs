using System;
using System.Collections.Generic;
using System.Text;
using RentACloth.Data.Models;

namespace RentACloth.Services.Contracts
{
    public interface ICategoryService
    {
        void AddMainCategory(string name);

        IEnumerable<Category> GetCategories();

        Category GetCategoryById(int id);

        bool EditCategory(int id, string name);

        bool DeleteCategory(int id);
    }
}
