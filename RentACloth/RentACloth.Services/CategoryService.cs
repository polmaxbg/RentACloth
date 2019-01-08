using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RentACloth.Common;
using RentACloth.Data;
using RentACloth.Data.Models;
using RentACloth.Services.Contracts;

namespace RentACloth.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly IRepository<Category> categoryRepository;
        private readonly RentAClothContext db;

        public CategoryService(IRepository<Category> categoryRepository, RentAClothContext db)
        {
            this.categoryRepository = categoryRepository;
            this.db = db;
        }

        public void AddMainCategory(string name)
        {
            var category = new Category()
            {
                Name = name
            };
            this.categoryRepository.Add(category);
            this.categoryRepository.SaveChanges();
        }

        public IEnumerable<Category> GetCategories()
        {
            var categories = this.categoryRepository.All().Include(x=>x.ChildCategories);
            return categories;
        }

        public Category GetCategoryById(int id)
        {
            var category = this.categoryRepository.All().FirstOrDefault(x => x.Id == id);
            return category;
        }

        public bool EditCategory(int id, string name)
        {
            var category = this.categoryRepository.All().FirstOrDefault(x => x.Id == id);

            if (category == null)
            {
                //throw new InvalidOperationException("There is no category with this id");
                return false;
            }

            category.Name = name;
            this.categoryRepository.SaveChanges();

            return true;
        }

        public bool DeleteCategory(int id)
        {
            var category = this.categoryRepository.All().Include(x=>x.ChildCategories).FirstOrDefault(x => x.Id == id);

            if (category == null || category.ChildCategories.Count!=0)
            {
                //throw new InvalidOperationException("There is no category with this id");
                return false;
            }

            this.db.Categories.Remove(category);
            this.categoryRepository.SaveChanges();

            return true;
        }
    }
}
