using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentACloth.Services.Contracts;

namespace RentACloth.Areas.Administration.Controllers
{
    public class HomeController : AdministratorController
    {
        private readonly ICategoryService categoryService;

        public HomeController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var categories = categoryService.GetCategories();
            return View(categories);
        }
    }
}