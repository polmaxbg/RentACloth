using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentACloth.Services.Contracts;
using RentACloth.Services.Models.Addresses;

namespace RentACloth.Controllers
{
    public class AddressController:BaseController
    {
        private readonly IAddressService addressService;

        public AddressController(IAddressService addressService)
        {
            this.addressService = addressService;
        }

        public IActionResult Add(IndexAddressViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Create", "Orders");
            }

            var adress = this.addressService.CreateAddress(model.DeliveryAddress, model.City, model.AddressDetails);

            this.addressService.AddAddressToUser(this.User.Identity.Name, adress);

            return this.RedirectToAction("Create", "Orders");
        }
    }
}
