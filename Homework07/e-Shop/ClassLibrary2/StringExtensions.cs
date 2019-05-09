using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public static class StringExtensions
    {
        public static string AddCurrency(this string price, string currency)
        {
            return $"{price} {currency}";
        }
    }
}
