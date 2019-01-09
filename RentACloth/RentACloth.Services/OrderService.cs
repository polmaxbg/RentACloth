using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RentACloth.Common;
using RentACloth.Data;
using RentACloth.Data.Models;
using RentACloth.Services.Contracts;

namespace RentACloth.Services
{
    public class OrderService:IOrderService
    {
        private readonly IUserService userService;
        private readonly IShoppingBagService shoppingBagService;
        private readonly IRepository<Order> orderRepository;

        private readonly RentAClothContext db;


        public OrderService(IUserService userService, IShoppingBagService shoppingBagService, IRepository<Order> orderRepository, RentAClothContext db)
        {
            this.userService = userService;
            this.shoppingBagService = shoppingBagService;
            this.orderRepository = orderRepository;
            this.db = db;
        }


        public Order CreateOrder(string username)
        {
            var user = this.userService.GetUserByUsername(username);

            var order = new Order()
            {
                User = user
            };

            this.db.Orders.Add(order);
            this.orderRepository.SaveChanges();
            return order;
        }

        public Order GetOrderById(int id)
        {
            return this.orderRepository.All().FirstOrDefault(x => x.Id == id);
        }

        public Order GetOrderByUsername(string username)
        {
            var user = this.userService.GetUserByUsername(username);
            var order = this.db.Orders.Include(x => x.DeliveryAddress).Include(x=>x.OrderProducts)
                .LastOrDefault(x => x.User.UserName == username);

            return order;
        }

        public IEnumerable<Order> GetUserOrders(string userName)
        {
            var order = this.orderRepository.All().Where(x => x.User.UserName == userName).ToList();

            return order;
        }

        public void SetOrder(Order order, string fullName, string phoneNumber, int deliveryAddressId)
        {
            order.Recepient = fullName;
            order.PhoneNumber = phoneNumber;
            order.DeliveryAddressId = deliveryAddressId;

            this.db.Orders.Update(order);
            this.orderRepository.SaveChanges();
        }

        public void CompleteOrder(string username)
        {
            var order = this.orderRepository.All().LastOrDefault(x => x.User.UserName == username);

            if (order==null)
            {
                return;
            }


            var shoppingBagProducts = this.shoppingBagService.GetAllShoppingBagProducts(username).ToList();
            if (shoppingBagProducts.Count==0)
            {
                return;
            }

            var orderProducts = new List<OrderProduct>();

            foreach (var product in shoppingBagProducts)
            {
                var orderProduct = new OrderProduct
                {
                    Order = order,
                    Product = product.Product,
                    ProductQuantity = product.Quantity,
                    ProductName = product.Product.Name,
                    ProductPrice = product.Product.Price,
                    Date = DateTime.Now
                };
                orderProducts.Add(orderProduct);
            }

            this.shoppingBagService.DeleteAllProduct(username);

            order.OrderDate = DateTime.Now;
            order.OrderProducts = orderProducts;
            foreach (var quantity in orderProducts)
            {
                order.Quantity = quantity.ProductQuantity;
            }
            order.TotalPrice = order.OrderProducts.Sum(x => x.ProductQuantity * x.ProductPrice);

            this.orderRepository.SaveChanges();
        }

        
    }
}
