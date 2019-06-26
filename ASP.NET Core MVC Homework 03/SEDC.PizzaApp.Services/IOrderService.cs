using SEDC.PizzaApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzaApp.Services
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();
        Order GetOrderById(int id);
        void CreateOrder(Order Order);
        void UpdateOrder(Order Order);
        void DeleteOrderById(int id);
    }
}
