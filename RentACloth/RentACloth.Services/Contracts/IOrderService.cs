using System;
using System.Collections.Generic;
using System.Text;
using RentACloth.Data.Models;

namespace RentACloth.Services.Contracts
{
    public interface IOrderService
    {
        Order CreateOrder(string username);
        Order GetOrderById(int id);
        Order GetOrderByUsername(string username);

        IEnumerable<Order> GetUserOrders(string userName);
        void SetOrder(Order order, string fullName, string phoneNumber, int deliveryAddressId);
        void CompleteOrder(string username);
    }
}
