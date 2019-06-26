using SEDC.PizzaApp.DataAccess;
using SEDC.PizzaApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzaApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAll();
        }

        public Order GetOrderById(int id)
        {
            return _orderRepository.GetById(id);
        }

        public void CreateOrder(Order order)
        {
            _orderRepository.Create(order);
        }

        public void UpdateOrder(Order order)
        {
            _orderRepository.Update(order);
        }

        public void DeleteOrderById(int id)
        {
            _orderRepository.Delete(id);
        }
    }
}
