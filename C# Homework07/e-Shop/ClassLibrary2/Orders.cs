using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ClassLibrary1
{
    public class Orders
    {
        public Customer Customer = new Customer();
        public List<Product> Products = new List<Product>();
        public decimal TotalAmount { get; set; }
        public DateTime Date { get; set; }

        public static string SavingOrder(ref Orders order)
        {
            string orderLog = "";

            if (order.TotalAmount >= 1000)
            {
                orderLog = $"$ Date: {order.Date} Name: {order.Customer.Name}, Total amount: {order.TotalAmount}, Products: ";

                foreach (Product product in order.Products)
                {
                    orderLog += $" {product.Name} {product.Price}";
                }
            }
            else
            {
                if (order.TotalAmount < 1000)
                {
                    orderLog = $"# Date: {order.Date} Name: {order.Customer.Name}, Total amount: {order.TotalAmount}, Products: ";

                    foreach (Product product in order.Products)
                    {
                        orderLog += $" {product.Name} {product.Price}";
                    }
                }
            }

            return orderLog;
        }

        public static void PrintOrderHistory(string sign, string filePath, string user)
        {
            foreach (string line in File.ReadAllLines(filePath))
            {
                if (line.Contains($"{sign}") && line.Contains(user))
                {
                    string result = line.Replace("#", "").Replace("$", "");
                    Console.WriteLine(result);
                }
                    
            }
        }
    }
}
