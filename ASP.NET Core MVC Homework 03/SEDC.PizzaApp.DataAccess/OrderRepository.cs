using SEDC.PizzaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.PizzaApp.DataAccess
{
    public class OrderRepository : IRepository<Order>
    {
        public List<Order> GetAll()
        {
            return StorageDB.Orders;
        }

        public Order GetById(int id)
        {
            return StorageDB.Orders.FirstOrDefault(x => x.Id == id);
        }

        public void Create(Order order)
        {
            StorageDB.OrderId++;
            order.Id = StorageDB.OrderId;
            StorageDB.Orders.Add(order);
        }

        public void Update(Order entity)
        {
            Order Order = StorageDB.Orders.FirstOrDefault(x => x.Id == entity.Id);
            if (Order != null)
            {
                int index = StorageDB.Orders.IndexOf(Order);
                StorageDB.Orders[index] = entity;
            }
        }

        public void Delete(int id)
        {
            Order Order = StorageDB.Orders.FirstOrDefault(x => x.Id == id);
            if (Order != null)
            {
                StorageDB.Orders.Remove(Order);
            }
        }
    }
}
