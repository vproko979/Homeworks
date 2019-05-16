using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class ShippingProvider
    {
        public string Name { get; set; }
        public ShippingProvider(string name = "")
        {
            Name = name;
        }        

        public delegate void DeliveryHandler(object service, OrderEventArgs news);

        public event DeliveryHandler OrderSend;

        public void Send(ShippingProvider provider, string name, string street, string number, string place)
        {

            OrderEventArgs shipment = new OrderEventArgs(name, street, number, place, provider);

            if (OrderSend != null)
            {
                OrderSend(this, shipment);
            }
        }
    }
}
