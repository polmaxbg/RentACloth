using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentACloth.Data.Models;
using RentACloth.Data.Models.Entities;
using RentACloth.Services.Mapping;

namespace RentACloth.Models.ProductsViewModel
{
    public class CreateProductViewModel:IMapFrom<Product>,IMapTo<Product>,IMapFrom<Cloth>,IMapTo<Cloth>,IHaveCustomMappings
    {
        [Display(Name = "Име на продукта")]
        [Required(ErrorMessage = "Моля изберете \"{0}\".")]
        public string Name { get; set; }

        [Display(Name = "Цена")]
        [Required(ErrorMessage = "Моля изберете \"{0}\".")]
        public decimal Price { get; set; }

        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Моля изберете \"{0}\".")]
        public string Description { get; set; }

        
        public string Size { get; set; }

        [Display(Name = "Тип на продукта (например: Shoe, Cloth, Watch, Accessories)")]
        [Required(ErrorMessage = "Моля изберете \"{0}\".")]
        public string ProductType { get; set; }

        [Display(Name = "Име на категория (например: Обувки, Дрехи, Часовници, Аксесоари)")]
        [Required(ErrorMessage = "Моля изберете \"{0}\".")]
        public string CategoryName { get; set; }

        [Display(Name = "Марка")]
        [Required(ErrorMessage = "Моля изберете \"{0}\".")]
        public string BrandName { get; set; }

        [Display(Name = "Снимка")]
        [Required(ErrorMessage = "Моля изберете \"{0}\".")]
        public string ImageUrl { get; set; }

        [Display(Name = "Под категория")]
        [Required(ErrorMessage = "Моля изберете \"{0}\".")]
        public int ChildCategoryId { get; set; }
        public ICollection<SelectListItem> ChildCategories { get; set; }
        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Product, CreateProductViewModel>()
                .ForMember(x => x.Name, x => x.MapFrom(y => y.Name))
                .ForMember(x => x.ProductType, x => x.MapFrom(y => y.ProductType))
                .ForMember(x=>x.CategoryName,x=>x.MapFrom(y=>y.CategoryName))
                .ForMember(x => x.BrandName, x => x.MapFrom(y => y.BrandName));
        }
    }
}