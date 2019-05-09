using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Vendor
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public Vendor(string name, List<Product> products = null)
        {
            Name = name;
            Products = products;
        }
        public static void ListVendors(List<Vendor> vendors)
        {
            int num = 1;
            Console.Clear();
            Console.WriteLine("List of vendors:");
            Console.WriteLine();
            foreach (var vendor in vendors)
            {
                Console.WriteLine("{0}) {1}", num, vendor.Name);
                num++;
            }
        }
    }
}
