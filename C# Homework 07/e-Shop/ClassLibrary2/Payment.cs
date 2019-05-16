using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class Payment
    {
        public string Name { get; set; }

        public Payment(string name)
        {
            Name = name;
        }

        public delegate void PaymentHandler(object service, PaymentEventArgs e);
        public event PaymentHandler PaymentProcessing;

        public void Paying(Payment provider, string info, string totalAmount)
        {
            PaymentEventArgs payment = new PaymentEventArgs(provider.Name, info, totalAmount);

            if (PaymentProcessing != null)
            {
                PaymentProcessing(this, payment);
            }
        }
    }
}
