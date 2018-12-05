using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RentACloth.Common;
using RentACloth.Data;
using RentACloth.Data.Models;
using RentACloth.Services.Models.Categories;
using RentACloth.Services.Mapping;

namespace RentACloth.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly IRepository<Category> categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IEnumerable<CategoryIdAndNameViewModel> GetAll()
        {
            var categories = this.categoryRepository.All().OrderBy(x => x.Name).To<CategoryIdAndNameViewModel>().ToList();
            return categories;
        }
    }
}
