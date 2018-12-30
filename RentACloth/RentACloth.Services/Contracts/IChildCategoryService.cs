﻿using System;
using System.Collections.Generic;
using System.Text;
using RentACloth.Data.Models;

namespace RentACloth.Services.Contracts
{
    public interface IChildCategoryService
    {
        IEnumerable<ChildCategory> GetChildCategories();

        ChildCategory GetChildCategoryById(int id);

        ChildCategory CreateChildCategory(string name, int categoryId);

        bool EditChildCategory(int id, string name, int categoryId);

        bool DeleteChildCategory(int id);
    }
}
