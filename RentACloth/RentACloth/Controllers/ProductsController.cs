using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentACloth.Data.Models;
using RentACloth.Data.Models.Entities;
using RentACloth.Models.Home;
using RentACloth.Models.ProductsViewModel;
using RentACloth.Services.Contracts;
using RentACloth.Services.Mapping;
using RentACloth.Services.Models.Home;

namespace RentACloth.Controllers
{
    public class ProductsController:BaseController
    {
        private readonly IShoesService shoesService;
        private readonly IClothService clothesService;
        private readonly IAccessoriesService accessoriesService;
        private readonly IWatchesService watchesService;
        private readonly IProductService productService;
        private const string ADMIN_ROLE = "Admin";



        public ProductsController(IShoesService shoesService, IClothService clothesService, IAccessoriesService accessories, IWatchesService watchesService, IProductService productService)
        {
            this.shoesService = shoesService;
            this.clothesService = clothesService;
            this.accessoriesService = accessories;
            this.watchesService = watchesService;
            this.productService = productService;
        }

        public IActionResult AllShoes()
        {
            var shoes = this.shoesService.AllShoes();
            
            var viewModel = new IndexViewModel
            {
                Products = shoes
            };
            return this.View(viewModel);
        }

        public IActionResult AllClothes()
        {
            var clothes = this.clothesService.AllClothes();

            var viewModel = new IndexViewModel
            {
                Products = clothes
            };
            return this.View(viewModel);
        }

        public IActionResult AllAccessories()
        {
            var clothes = this.accessoriesService.AllAccessories();

            var viewModel = new IndexViewModel
            {
                Products = clothes
            };
            return this.View(viewModel);
        }

        public IActionResult AllWatches()
        {
            var clothes = this.watchesService.AllWatches();

            var viewModel = new IndexViewModel
            {
                Products = clothes
            };
            return this.View(viewModel);
        }

        public IActionResult All()
        {
            var products = this.productService.GetAllProducts();

            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = this.productService.GetProductById<ProductDetailsViewModel>(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [Authorize(Roles = ADMIN_ROLE)]
        public IActionResult CreateProduct()
        {
            var childCategories = this.productService.GetChildCategories();

            var categories = childCategories.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();

            var model = new CreateProductViewModel { ChildCategories = categories };

            return View(model);
        }

        [Authorize(Roles = ADMIN_ROLE)]
        [HttpPost]
        public IActionResult CreateProduct(CreateProductViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }
            var product = Mapper.Map<Product>(model);

            this.productService.AddProduct(product);

            return RedirectToAction(nameof(All));

        }

        [Authorize(Roles = ADMIN_ROLE)]
        public IActionResult Edit(int id)
        {
            var product = this.productService.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            var childCategories = this.productService.GetChildCategories();

            ViewData["ChildCategoryId"] = childCategories.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();

            var model = Mapper.Map<EditProductViewModel>(product);

            return View(model);
        }

        [Authorize(Roles = ADMIN_ROLE)]
        [HttpPost]
        public IActionResult Edit(EditProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                //TODO:Check
                var childCategories = this.productService.GetChildCategories();

                ViewData["ChildCategoryId"] = childCategories.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToList();

                return View(model);
            }

            var product = Mapper.Map<Product>(model);

            this.productService.EditProduct(product);

            //if (model.FormImages != null)
            //{
            //    int existingImages = productService.GetImages(product.Id).Count();
            //    var imageUrls = await this.imageService.UploadImages(model.FormImages.ToList(), existingImages,
            //        GlobalConstans.PRODUCT_PATH_TEMPLATE, product.Id);

            //    this.productService.AddImageUrls(product.Id, imageUrls);
            //}

            return RedirectToAction(nameof(All));
        }
        public IActionResult Delete(int id)
        {
            this.productService.RemoveProduct(id);
            return this.RedirectToAction(nameof(All));
        }
    }

    public class EditProductViewModel : IMapFrom<Product>, IMapTo<Product>, IHaveCustomMappings
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public string ProductType { get; set; }
        public string EventType { get; set; }
        public int ChildCategoryId { get; set; }
        public string BrandName { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Product, EditProductViewModel>()
                .ForMember(x => x.Name, x => x.MapFrom(y => y.Name))
                .ForMember(x => x.ProductType, x => x.MapFrom(y => y.ProductType))
                .ForMember(x => x.EventType, x => x.MapFrom(y => y.EventType))
                .ForMember(x=>x.BrandName,x=>x.MapFrom(y=>y.BrandName));
        }
    }

    public class CreateProductViewModel:IMapFrom<Product>,IMapTo<Product>,IMapFrom<Cloth>,IMapTo<Cloth>,IHaveCustomMappings
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public string ProductType { get; set; }
        public string EventType { get; set; }
        public string BrandName { get; set; }
        public string ImageUrl { get; set; }

        public int ChildCategoryId { get; set; }
        public ICollection<SelectListItem> ChildCategories { get; set; }
        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Product, CreateProductViewModel>()
                .ForMember(x => x.Name, x => x.MapFrom(y => y.Name))
                .ForMember(x => x.ProductType, x => x.MapFrom(y => y.ProductType))
                .ForMember(x => x.EventType, x => x.MapFrom(y => y.EventType))
                .ForMember(x => x.BrandName, x => x.MapFrom(y => y.BrandName));
        }
    }
}
