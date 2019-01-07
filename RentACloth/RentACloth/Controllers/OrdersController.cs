using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACloth.Common;
using RentACloth.Data.Models;
using RentACloth.Models.Оrders;
using RentACloth.Services.Contracts;
using RentACloth.Services.Mapping;

namespace RentACloth.Controllers
{
    public class OrdersController : BaseController
    {
        private const string ERROR_MESSAGE = "Моля добавете продукти в кошницата!";
        private const int DELIVERY_PRICE = 5;

        private readonly IAddressService adressesService;
        private readonly IUserService userService;
        private readonly IOrderService orderService;
        private readonly IShoppingBagService shoppingBagService;
        private readonly IMapper mapper;
        private readonly IRepository<OrderProduct> orderProductRepository;

        public OrdersController(IAddressService adressesService, IUserService userService, IOrderService orderService, IShoppingBagService shoppingBagService, IRepository<OrderProduct> orderProductRepository)
        {
            this.adressesService = adressesService;
            this.userService = userService;
            this.orderService = orderService;
            this.shoppingBagService = shoppingBagService;
            this.orderProductRepository = orderProductRepository;
        }

        public IActionResult Create()
        {
            if (!this.shoppingBagService.AnyProducts(this.User.Identity.Name))
            {
                this.TempData["error"] = ERROR_MESSAGE;
                return RedirectToAction("Index", "Home");
            }

            var order = this.orderService.CreateOrder(this.User.Identity.Name);
            var address = this.adressesService.GetAllAddressByUser(this.User.Identity.Name);

            var viewModel = Mapper.Map<IList<OrdersAddressViewModel>>(address);

            var user = this.userService.GetUserByUsername(this.User.Identity.Name);
            var fullName = $"{user.FirstName} {user.LastName}";


            var createOrderViewModel = new CreateOrderViewModel
            {
                OrderAddressesViewModel = viewModel.ToList(),
                FullName = fullName,
                PhoneNumber = user.PhoneNumber
            };

            return this.View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(CreateOrderViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var order = this.orderService.GetOrderByUsername(this.User.Identity.Name);
                if (order == null)
                {
                    return this.RedirectToAction("Index", "ShoppingBag");
                }

                this.orderService.SetOrder(order, model.FullName, model.PhoneNumber, model.DeliveryAddressId.Value);

                return this.RedirectToAction(nameof(Confirm));
            }
            else
            {
                var addresses = this.adressesService.GetAllAddressByUser(this.User.Identity.Name);
                var addressesViewModel = Mapper.Map<IList<OrdersAddressViewModel>>(addresses);

                model.OrderAddressesViewModel = addressesViewModel.ToList();
                return this.View(model);
            }
        }

        public IActionResult Confirm()
        {
            if (!this.shoppingBagService.AnyProducts(this.User.Identity.Name))
            {
                this.TempData["error"] = ERROR_MESSAGE;
                return RedirectToAction("Index", "Home");
            }

            var order = this.orderService.GetOrderByUsername(this.User.Identity.Name);
            var orderViewModel = new ConfirmOrderViewModel()
            {
                TotalPrice = order.TotalPrice,
                Recipient = order.Recepient,
                PhoneNumber = order.PhoneNumber,
                DeliveryAddressCityName = order.DeliveryAddress.City,
                DeliveryAddressStreet = order.DeliveryAddress.Street,
                DeliveryAddressDescription = order.DeliveryAddress.AddressDetails,
                DeliveryPrice = DELIVERY_PRICE
            };

            return this.View(orderViewModel);
        }

        public IActionResult Complete(int id)
        {
            if (!this.shoppingBagService.AnyProducts(this.User.Identity.Name))
            {
                this.TempData["error"] = ERROR_MESSAGE;
                return RedirectToAction("Index", "Home");
            }

            var order = this.orderService.GetOrderByUsername(this.User.Identity.Name);
            this.orderService.CompleteOrder(this.User.Identity.Name);

            //TODO:
            return this.RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult MyOrders()
        {

            var orders = this.orderProductRepository.All().Where(x => x.Order.User.UserName == this.User.Identity.Name).Select(x => new MyOrderViewModel()
            {
                Id = x.OrderId,
                Quantity = x.ProductQuantity,
                TotalPrice = x.Order.TotalPrice,
                ProductName = x.ProductName,
                ProductPrice = x.Product.Price.ToString(),
                ProductId = x.ProductId
            });


            var viewModel = new MyOrdersViewModel() { Orders = orders };

            return this.View(viewModel);
        }
    }
}
