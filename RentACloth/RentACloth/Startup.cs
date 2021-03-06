﻿using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentACloth.Common;
using RentACloth.Controllers;
using RentACloth.Data;
using RentACloth.Data.Models;
using RentACloth.Middlewares;
using RentACloth.Models.Categories;
using RentACloth.Models.ChildCategories;
using RentACloth.Models.Home;
using RentACloth.Models.ProductsViewModel;
using RentACloth.Models.ShoppingBag;
using RentACloth.Models.Оrders;
using RentACloth.Services;
using RentACloth.Services.Contracts;
using RentACloth.Services.Mapping;
using RentACloth.Services.Models.Addresses;
using RentACloth.Services.Models.Home;
using IndexViewModel = RentACloth.Models.Home.IndexViewModel;

namespace RentACloth
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AutoMapperConfig.RegisterMappings(
                typeof(IndexProductViewModel).Assembly,
                typeof(ProductDetailsViewModel).Assembly,
                typeof(IndexAddressViewModel).Assembly,
                typeof(CategoryViewModel).Assembly,
                typeof(EditChildCategoryViewModel).Assembly,
                typeof(AllChildCategoryViewModel).Assembly,
                typeof(EditProductViewModel).Assembly,
                typeof(IndexCategoryViewModel).Assembly,
                typeof(IndexChildCategoryViewModel).Assembly,
                typeof(IndexViewModel).Assembly,
                typeof(ShoppingBagProductsViewModel).Assembly,
                typeof(OrdersAddressViewModel).Assembly

             );

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<RentAClothContext>(options =>
                options.UseSqlServer(
                    this.Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<RentAClothUser, IdentityRole>(
                     options =>
                     {
                         options.Password.RequiredLength = 3;
                         options.Password.RequireLowercase = false;
                         options.Password.RequireNonAlphanumeric = false;
                         options.Password.RequireUppercase = false;
                         options.Password.RequireDigit = false;
                     }
                 )
                .AddDefaultTokenProviders()
                .AddDefaultUI()
                .AddEntityFrameworkStores<RentAClothContext>();

            services.AddDistributedMemoryCache();

            
            // Application services

            services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));
            services.AddScoped<IShoesService, ShoesService>();
            services.AddScoped<IClothService, ClothesService>();
            services.AddScoped<IAccessoriesService, AccessoriesService>();
            services.AddScoped<IWatchesService, WatchesService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IShoppingBagService, ShoppingBagService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IChildCategoryService, ChildCategoryService>();
            services.AddScoped<ICategoryService, CategoryService>();



            services.AddAuthentication().AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            });

            services.AddAuthentication().AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = Configuration["Authentication:Google:ClientId"];
                googleOptions.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseSeedDataMiddleware();

            app.UseMvc(routes =>
            {

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
