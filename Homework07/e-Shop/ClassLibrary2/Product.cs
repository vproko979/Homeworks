using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Product
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Product(int code = 0, string name = "", decimal price = 0M, int quantity = 0)
        {
            Code = code;
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public static void ListAllProducts(List<Product> list1, List<Product> list2, List<Product> list3)
        {
            var products = list1.Concat(list2).Concat(list3).OrderBy(product => product.Name).ToList();
            Console.WriteLine("List of all products:");
            Console.WriteLine();
            PrintList(products);
        }
        public static void AscendingByName(Vendor vendor)
        {
            var products = vendor.Products.OrderBy(product => product.Name).ToList();
            Console.WriteLine($"{vendor.Name}:");
            Console.WriteLine();
            PrintList(products);
        }

        public static void AscendingByName2(List<Product> products)
        {
            var result = products.OrderBy(product => product.Name).ToList();
            PrintList(result);
        }

        public static void AscendingByPrice(Vendor vendor)
        {
            var products = vendor.Products.OrderBy(product => product.Price).ToList();
            Console.WriteLine($"{vendor.Name}:");
            Console.WriteLine();
            PrintList(products);
        }

        public static void AscendingByPrice2(List<Product> products)
        {
            var result = products.OrderBy(product => product.Price).ToList();
            PrintList(result);
        }

        public static void DescendingByName(Vendor vendor)
        {
            var products = vendor.Products.OrderByDescending(product => product.Name).ToList();

            Console.WriteLine($"{vendor.Name}:");
            Console.WriteLine();
            PrintList(products);
        }

        public static void DescendingByName2(List<Product> products)
        {
            var result = products.OrderByDescending(product => product.Name).ToList();
            PrintList(result);
        }

        public static void DescendingByPrice(Vendor vendor)
        {
            var products = vendor.Products.OrderByDescending(product => product.Price).ToList();

            Console.WriteLine($"{vendor.Name}:");
            Console.WriteLine();
            PrintList(products);
        }

        public static void DescendingByPrice2(List<Product> products)
        {
            var result= products.OrderByDescending(product => product.Price).ToList();
            PrintList(result);
        }

        public static void PrintList(List<Product> products)
        {
            Console.WriteLine("{0,-7} {1,-15} {2,15}\n", "Code", "Name", "Price");
            foreach (var product in products)
            {
                var price = string.Format("{0:n}", product.Price).AddCurrency("MKD");
                Console.WriteLine("{0,-7:D4} {1,-15} {2,15}", product.Code, product.Name, price);
            }
        }

        public static void PrintList2(List<Product> products)
        {
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"Order {i + 1}:");
                Console.WriteLine("{0,-15} {1,-7} {2,13}", "Name", "Qty.", "Price");
                var price = string.Format("{0:n}", products[i].Price).AddCurrency("MKD");
                Console.WriteLine("{0,-15} {1,-7} {2,13}", products[i].Name, products[i].Quantity, price);
                Console.WriteLine();
            }
        }

        public static void DisplayByOptions(string searchOptions, List<Vendor> vendorsDeserialized)
        {
            string strValue = searchOptions.Substring(0, 2);
            int numValue = int.Parse(searchOptions.Substring(searchOptions.Length - 1));
            if (strValue == "11")
            {
                AscendingByName(vendorsDeserialized[numValue - 1]);
            }
            else
            {
                if (strValue == "12")
                {
                    DescendingByName(vendorsDeserialized[numValue - 1]);
                }
                else
                {
                    if (strValue == "21")
                    {
                        AscendingByPrice(vendorsDeserialized[numValue - 1]);
                    }
                    else
                    {
                        if (strValue == "22")
                        {
                            DescendingByPrice(vendorsDeserialized[numValue - 1]);
                        }
                    }
                }
            }
        }

        public static void DisplayByOptions2(List<Product> result, Vendor vendor, string searchOption)
        {
            if (searchOption == "11")
            {
                Console.WriteLine();
                Console.WriteLine($"VENDOR: {vendor.Name}");
                AscendingByName2(result);
                Console.WriteLine();
            }
            else
            {
                if (searchOption == "12")
                {
                    Console.WriteLine();
                    Console.WriteLine($"VENDOR: {vendor.Name}");
                    DescendingByName2(result);
                    Console.WriteLine();
                }
                else
                {
                    if (searchOption == "21")
                    {
                        Console.WriteLine();
                        Console.WriteLine($"VENDOR: {vendor.Name}");
                        AscendingByPrice2(result);
                        Console.WriteLine();
                    }
                    else
                    {
                        if (searchOption == "22")
                        {
                            Console.WriteLine();
                            Console.WriteLine($"VENDOR: {vendor.Name}");
                            DescendingByPrice2(result);
                            Console.WriteLine();
                        }
                    }
                }
            }
        }

        public static void FindProduct2(decimal search, List<Vendor> vendors, ref Product productMatch)
        {
            
            foreach (var vendor in vendors)
            {
                foreach (var product in vendor.Products)
                {
                    if (product.Code == search)
                    {
                        productMatch = product;
                        return;
                    }
                }
            }

        }        

        public static void FindProducts(List<Vendor> vendors, string searchOption, string match)
        {
            int count = 0;
            foreach (Vendor vendor in vendors)
            {
                var result = vendor.Products.FindAll(product => product.Name.ToLower().Contains(match.ToLower())).ToList();

                if (result.Count != 0)
                {
                    count += result.Count;
                    DisplayByOptions2(result, vendor, searchOption);
                }
            }

            if (count == 0)
            {
                Console.WriteLine();
                Console.WriteLine($"Sorry, no match.");
            }
        }

        public static string TotalCost(List<Product> products)
        {
            decimal total = 0M;
            
            foreach (var product in products)
            {
                total += product.Price * product.Quantity;
            }

            var price = string.Format("{0:n}", total).AddCurrency("MKD");
            return price;
        }

        public static decimal TotalCost2(List<Product> products)
        {
            decimal total = 0M;

            foreach (var product in products)
            {
                total += product.Price * product.Quantity;
            }

            return total;
        }

        public static void DisplayOrderList(List<Product> listOfOrders)
        {
            Console.WriteLine("List of your orders:");
            Product.PrintList2(listOfOrders);
            Console.WriteLine();
            Console.WriteLine($"Total cost : {Product.TotalCost(listOfOrders)}");
            Console.WriteLine();
        }
    }
}
