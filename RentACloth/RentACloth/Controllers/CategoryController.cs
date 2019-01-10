using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACloth.Models.Categories;
using RentACloth.Services.Contracts;

namespace RentACloth.Controllers
{
    public class CategoryController : BaseController
    {
        private const string ADMIN_ROLE = "Admin";
        private readonly ICategoryService categoryService;


        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [Authorize(Roles = ADMIN_ROLE)]
        public IActionResult Edit(int id)
        {
            var category = this.categoryService.GetCategoryById(id);

            if (category == null)
            {
                return RedirectToAction("All");
            }

            var categoryViewModel = Mapper.Map<CategoryViewModel>(category);

            return View(categoryViewModel);
        }

        [Authorize(Roles = ADMIN_ROLE)]
        [HttpPost]
        public IActionResult Edit(CategoryViewModel model)
        {
            this.categoryService.EditCategory(model.Id, model.Name);

            return RedirectToAction("All");
        }

        [Authorize(Roles = ADMIN_ROLE)]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize(Roles = ADMIN_ROLE)]
        [HttpPost]
        public IActionResult Add(CategoryViewModel model)
        {
            this.categoryService.AddMainCategory(model.Name);

            return RedirectToAction("All");
        }


        [Authorize(Roles = ADMIN_ROLE)]
        public IActionResult All()
        {
            var categories = this.categoryService.GetCategories();

            var categoriesViewModel = Mapper.Map<IList<CategoryViewModel>>(categories);

            return View(categoriesViewModel);
        }


        [Authorize(Roles = ADMIN_ROLE)]
        public IActionResult Delete(int id)
        {
            if (!this.categoryService.DeleteCategory(id))
            {
                TempData["error"] = "Не може да изтриете главна категория, защото съдържа други категории.";
            }

            return RedirectToAction(nameof(All));
        }
    }
}