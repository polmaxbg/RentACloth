using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACloth.Data.Models;
using RentACloth.Services.Contracts;
using RentACloth.Services.Mapping;
using RentACloth.Services.Models.Addresses;

namespace RentACloth.Controllers
{
    public class OrdersController:BaseController
    {
        private const string ERROR_MESSAGE = "Моля добавете продукти в кошницата!";
        private const int DELIVERY_PRICE = 5;

        private readonly IAddressService adressesService;
        private readonly IUserService userService;
        private readonly IOrderService orderService;
        private readonly IShoppingBagService shoppingBagService;

        public OrdersController(IAddressService adressesService, IUserService userService, IOrderService orderService, IShoppingBagService shoppingCartService)
        {
            this.adressesService = adressesService;
            this.userService = userService;
            this.orderService = orderService;
            this.shoppingBagService = shoppingCartService;
        }

        public IActionResult Create()
        {
            if (!this.shoppingBagService.AnyProducts(this.User.Identity.Name))
            {
                this.TempData["error"] = ERROR_MESSAGE;
                return RedirectToAction("Index", "Home");
            }

            var order = this.orderService.CreateOrder(this.User.Identity.Name);
            var address= this.adressesService.GetAllAddressByUser(this.User.Identity.Name);

            var viewModel = new OrdersAddressViewModel()
            {
                Addresses = address
            };

            var user = this.userService.GetUserByUsername(this.User.Identity.Name);
            var fullName = $"{user.FirstName} {user.LastName}";


            var createOrderViewModel = new CreateOrderViewModel
            {
                OrderAddressesViewModel = viewModel.Addresses.ToList(),
                FullName = fullName,
                PhoneNumber = user.PhoneNumber
            };

            return this.View(createOrderViewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(CreateOrderViewModel model)
        {
            var order = this.orderService.GetOrderByUsername(this.User.Identity.Name);
            if (order == null)
            {
                return this.RedirectToAction("Index", "ShoppingBag");
            }
            
            this.orderService.SetOrder(order, model.FullName, model.PhoneNumber, model.DeliveryAddressId.Value);

            return this.RedirectToAction(nameof(Confirm));
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
            return this.RedirectToAction("Index","Home");
        }
    }

    public class ConfirmOrderViewModel:IMapFrom<Order>,IMapTo<Order>
    {
        public decimal TotalPrice { get; set; }

        public decimal DeliveryPrice { get; set; }

        public string Recipient { get; set; }

        public string PhoneNumber { get; set; }

        public string DeliveryAddressDescription { get; set; }

        public string DeliveryAddressStreet { get; set; }

        public string DeliveryAddressCityName { get; set; }
    }

    public class CreateOrderViewModel
    {
        public List<IndexAddressViewModel> OrderAddressesViewModel { get; set; }
        public IndexAddressViewModel OrderAdressViewModel { get; set; }

        [Display(Name = "Адрес на получаване")]
        [Required(ErrorMessage = "Моля изберете \"{0}\".")]
        public int? DeliveryAddressId { get; set; }

        [Display(Name = "Име на получателя")]
        [Required(ErrorMessage = "Моля въведете \"{0}\".")]
        public string FullName { get; set; }

        [Display(Name = "GSM номер")]
        [Required(ErrorMessage = "Моля въведете \"{0}\".")]
        public string PhoneNumber { get; set; }
    }

    public class OrdersAddressViewModel
    {
        public IEnumerable<IndexAddressViewModel> Addresses { get; set; }
    }
}
