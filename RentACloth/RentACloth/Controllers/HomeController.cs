using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentACloth.Models;
using RentACloth.Models.Home;
using RentACloth.Models.ProductsViewModel;
using RentACloth.Services.Contracts;
using RentACloth.Services.Models.Home;
using X.PagedList;
using IndexViewModel = RentACloth.Models.Home.IndexViewModel;

namespace RentACloth.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;
        private const int DEFAULT_PAGE_NUMBER = 1;
        private const int DEFAULT_PAGE_SIZE = 4;


        public HomeController(ICategoryService categoryService, IProductService productService)
        {
            this.categoryService = categoryService;
            this.productService = productService;
        }


        public IActionResult Index(IndexViewModel model)
        {
            var categories = this.categoryService.GetCategories();
            var products = this.productService.GetProductsByCategory(model.ChildCategoryId);

            var categoriesViewModel = Mapper.Map<IList<IndexCategoryViewModel>>(categories);
            var productsViewModel = Mapper.Map<IList<IndexProductViewModel>>(products);

            var pageNumber = model.PageNumber ?? DEFAULT_PAGE_NUMBER;
            var pageSize = model.PageSize ?? DEFAULT_PAGE_SIZE;
            var pageProducts = productsViewModel.ToPagedList(pageNumber, pageSize);

            model.ProductViewModel = pageProducts;
            model.CategoriesViewModel = categoriesViewModel;

            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
