using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class OrderEventArgs : EventArgs
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public ShippingProvider Provider { get; set; }

        public OrderEventArgs(string name, string street, string number, string city, ShippingProvider provider)
        {
            Name = name;
            Street = street;
            Number = number;
            City = city;
            Provider = provider;
        }
    }
}
