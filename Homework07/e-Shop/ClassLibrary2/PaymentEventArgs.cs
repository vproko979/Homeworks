using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class PaymentEventArgs : EventArgs
    {
        public string Name { get; set; }
        public string Info { get; set; }
        public string TotalAmount { get; set; }

        public PaymentEventArgs(string name, string info, string totalAmount)
        {
            Name = name;
            Info = info;
            TotalAmount = totalAmount;
        }
    }
}
