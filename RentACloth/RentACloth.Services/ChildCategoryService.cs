using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RentACloth.Common;
using RentACloth.Data;
using RentACloth.Data.Models;
using RentACloth.Services.Contracts;

namespace RentACloth.Services
{
    public class ChildCategoryService:IChildCategoryService
    {
        private readonly IRepository<ChildCategory> childCategoryRepository;
        private readonly RentAClothContext db;

        public ChildCategoryService(IRepository<ChildCategory> childCategoryRepository, RentAClothContext db)
        {
            this.childCategoryRepository = childCategoryRepository;
            this.db = db;
        }


        public IEnumerable<ChildCategory> GetChildCategories()
        {
            //TODO:Виж дали взима и продуктите
            var childCategories = this.childCategoryRepository.All();
            return childCategories;
        }

        public ChildCategory GetChildCategoryById(int id)
        {
            var childCategory = this.childCategoryRepository.All().FirstOrDefault(x => x.Id == id);
            return childCategory;
        }

        public ChildCategory CreateChildCategory(string name, int categoryId)
        {
            var childCategory = new ChildCategory
            {
                Name = name,
                CategoryId = categoryId
            };

            this.childCategoryRepository.Add(childCategory);
            this.childCategoryRepository.SaveChanges();

            return childCategory;
        }

        public bool EditChildCategory(int id, string name,  int categoryId)
        {
            var childCategory = this.childCategoryRepository.All().FirstOrDefault(x => x.Id == id);
            if (childCategory==null)
            {
                throw new InvalidOperationException("There is no category with this id");
            }

            childCategory.Name = name;
            childCategory.CategoryId = categoryId;

            this.childCategoryRepository.SaveChanges();

            return true;
        }

        public bool DeleteChildCategory(int id)
        {
            var category = this.childCategoryRepository.All().FirstOrDefault(x => x.Id == id);

            if (category == null || category.Products.Any())
            {
                throw new InvalidOperationException("There is no category with this id");
            }

            this.db.ChildCategories.Remove(category);
            this.childCategoryRepository.SaveChanges();

            return true;
        }
    }
}
