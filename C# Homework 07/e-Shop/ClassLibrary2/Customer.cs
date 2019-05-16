using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Customer
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Customer(string name = "", string username = "", string password = "")
        {
            Name = name;
            Username = username;
            Password = password;
            //OrderHistory = new string[1,2];
            //Archive = new List<List<Product>>();
        }

        public static string YourCity(int selection)
        {
            string city = "";

            if (selection == 1)
            {
                city = "Skopje";
            }
            else
            {
                if (selection == 2)
                {
                    city = "Bitola";
                }
                else
                {
                    if (selection == 3)
                    {
                        city = "Ohrid";
                    }
                    else
                    {
                        if (selection == 4)
                        {
                            city = "Stip";
                        }
                    }
                }
            }

            return city;
        }

        public void Subscribe(ShippingProvider provider)
        {
            provider.OrderSend += new ShippingProvider.DeliveryHandler(ShipmentSent);
        }

        public void ShipmentSent(object provider, OrderEventArgs shipment)
        {
            Console.Clear();
            Console.WriteLine("Shipping information:");
            Console.WriteLine();
            Console.WriteLine($"Name: {shipment.Name}");
            Console.WriteLine($"Street: {shipment.Street}");
            Console.WriteLine($"Number: {shipment.Number}");
            Console.WriteLine($"City: {shipment.City}");
            Console.WriteLine();
            Console.WriteLine($"Your shipment gonna be delivered by {shipment.Provider.Name}");
        }

        public void Subscribe2(Payment service)
        {
            service.PaymentProcessing += new Payment.PaymentHandler(Pay);
        }

        public void Pay(object provider, PaymentEventArgs payment)
        {
            Console.WriteLine("Payment method: " + payment.Name);
            Console.WriteLine();
            Console.WriteLine("Total amount: " + payment.TotalAmount);
            Console.WriteLine();
            Console.WriteLine(payment.Info);
        }
        
    }
}
