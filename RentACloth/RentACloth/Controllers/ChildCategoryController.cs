using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACloth.Common;
using RentACloth.Data.Models;
using RentACloth.Models.Categories;
using RentACloth.Models.ChildCategories;
using RentACloth.Services.Contracts;

namespace RentACloth.Controllers
{
    public class ChildCategoryController:BaseController
    {
        private const string ADMIN_ROLE = "Admin";
        private readonly IChildCategoryService childCategoryService;
        private readonly ICategoryService categoryService;
        private readonly IRepository<ChildCategory> childCategoryRepository;

        public ChildCategoryController(IChildCategoryService childCategoryService, ICategoryService categoryService, IRepository<ChildCategory> childCategoryRepository)
        {
            this.childCategoryService = childCategoryService;
            this.categoryService = categoryService;
            this.childCategoryRepository = childCategoryRepository;
        }


        [Authorize(Roles = ADMIN_ROLE)]
        public IActionResult Edit(int id)
        {
            var childCategory = this.childCategoryService.GetChildCategoryById(id);
            var categories = this.categoryService.GetCategories().ToList();

            if (childCategory == null)
            {
                return RedirectToAction(nameof(All));
            }

            var categoryViewModel = Mapper.Map<EditChildCategoryViewModel>(childCategory);
            categoryViewModel.Categories = categories;

            return View(categoryViewModel);
        }

        [Authorize(Roles = ADMIN_ROLE)]
        [HttpPost]
        public IActionResult Edit(EditChildCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories= this.categoryService.GetCategories().ToList();

                return this.View(model);
            }

            this.childCategoryService.EditChildCategory(model.Id, model.Name, (int)model.CategoryId);

            return RedirectToAction(nameof(All));
        }


        [Authorize(Roles = ADMIN_ROLE)]
        public IActionResult Add()
        {
            var categories = this.categoryService.GetCategories().ToList();

            var addViewModel = new AddChildCategoryViewModel
            {
                Categories = categories
            };

            return View(addViewModel);
        }

        [Authorize(Roles = ADMIN_ROLE)]
        [HttpPost]
        public IActionResult Add(AddChildCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = this.categoryService.GetCategories().ToList();

                return this.View(model);
            }

            var childCategory = this.childCategoryService
                                    .CreateChildCategory(model.Name,(int)model.CategoryId);

            return this.RedirectToAction(nameof(All));
        }

        [Authorize(Roles = ADMIN_ROLE)]
        public IActionResult All()
        {
            var childCategories = this.childCategoryService.GetChildCategories();
            var childCategoriesViewModel = Mapper.Map<IList<AllChildCategoryViewModel>>(childCategories);

            var categories = this.categoryService.GetCategories();
            var categoriesViewModel = Mapper.Map<IList<CategoryViewModel>>(categories);

            var childParentViewModel = new AllCategoriesViewModel
            {
                ChildCategoryViewModel = childCategoriesViewModel,
                CategoryViewModels = categoriesViewModel
            };

            return View(childParentViewModel);
        }

        [Authorize(Roles = ADMIN_ROLE)]
        public IActionResult Delete(int id)
        {
            if (!this.childCategoryService.DeleteChildCategory(id))
            {
                this.TempData["error"] = "Може да изтриете категория само ако не съдържа продукти!";
            }

            return RedirectToAction(nameof(All));
        }
    }
}
