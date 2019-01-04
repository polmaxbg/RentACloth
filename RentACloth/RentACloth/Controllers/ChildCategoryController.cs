using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACloth.Common;
using RentACloth.Data.Models;
using RentACloth.Services.Contracts;
using RentACloth.Services.Mapping;

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

    public class AllCategoriesViewModel
    {
        public ICollection<AllChildCategoryViewModel> ChildCategoryViewModel { get; set; }

        public ICollection<CategoryViewModel> CategoryViewModels { get; set; }
    }

    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int ChildCategoriesCount { get; set; }
    }

    public class AllChildCategoryViewModel:IMapFrom<Category>,IMapTo<Category>,IHaveCustomMappings
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public int ProductsCount { get; set; }
        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Category, AllChildCategoryViewModel>()
                .ForMember(x => x.CategoryName, x => x.MapFrom(y => y.Name));
        }
    }

    public class AddChildCategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Попълнете {0}!")]
        [Display(Name = "Име")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Изберете {0}!")]
        [Display(Name = "Главна категория")]
        public int? CategoryId { get; set; }

        public ICollection<Category> Categories { get; set; }
    }

    public class EditChildCategoryViewModel:IMapFrom<ChildCategory>,IMapTo<ChildCategory>
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Попълнете {0}!")]
        [Display(Name = "Име")]
        public string Name { get; set; }
        

        [Required(ErrorMessage = "Изберете {0}!")]
        [Display(Name = "Основна категория")]
        public int? CategoryId { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
