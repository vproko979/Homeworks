using ClassLibrary1;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Vendors, products & users
            //List<Product> list1 = new List<Product>
            //{
            //    new Product(0001, "Tuborg", 95.00M),
            //    new Product(0002, "Milka", 75.00M),
            //    new Product(0003, "Persil", 290.00M),
            //    new Product(0004, "Knorr", 45.00M),
            //    new Product(0005, "Wilkinson", 978.00M),
            //    new Product(0006, "Nivea", 210.00M),
            //    new Product(0007, "Lacalut", 195.00M),
            //    new Product(0008, "Johnnie Walker", 3247.00M),
            //    new Product(0009, "Nescafe", 75.00M)
            //};

            //List<Product> list2 = new List<Product>
            //{
            //    new Product(0010, "Heineken", 85.00M),
            //    new Product(0011, "Nestle", 65.00M),
            //    new Product(0012, "Tide", 270.00M),
            //    new Product(0013, "Maggi", 40.00M),
            //    new Product(0014, "Gillette", 835.00M),
            //    new Product(0015, "Dove", 105.00M),
            //    new Product(0016, "Colgate", 235.00M),
            //    new Product(0017, "Jack Daniel's", 2294.00M),
            //    new Product(0018, "Jacobs", 122.00M)
            //};

            //List<Product> list3 = new List<Product>
            //{
            //    new Product(0019, "Amstel", 90.00M),
            //    new Product(0020, "Toblerone", 70.00M),
            //    new Product(0021, "Ariel", 280.00M),
            //    new Product(0022, "Podravka", 35.00M),
            //    new Product(0023, "Balea", 435.00M),
            //    new Product(0024, "Old Spice", 105.00M),
            //    new Product(0025, "Oral-B", 249.00M),
            //    new Product(0026, "Jameson", 2337.00M),
            //    new Product(0027, "Franck", 79.00M)
            //};

            //Vendor market1 = new Vendor("TINEX", list1);
            //Vendor market2 = new Vendor("Vero", list2);
            //Vendor market3 = new Vendor("KAM", list3);

            //List<Vendor> vendors = new List<Vendor> { market1, market2, market3 };
            #endregion

            List<Vendor> vendorsDeserialized = new List<Vendor>();

            ////Json serialization
            string pathJsonSerialization = @"C:\Users\Master\Desktop\e-Shop\Products\Products.json";
            //string json = JsonConvert.SerializeObject(vendors, Formatting.Indented);
            //File.WriteAllText(pathJsonSerialization, json);

            //Json deserialization
            string readJson = File.ReadAllText(pathJsonSerialization);
            vendorsDeserialized = JsonConvert.DeserializeObject<List<Vendor>>(readJson);

            string filePath = @"C:\Users\Master\Desktop\e-Shop\Orders\Orders.txt";
            Customer john = new Customer("John Doe", "jdoe", "doe123");
            Customer bob = new Customer("Bob Bobsky", "bsky", "bob321");
            Customer mike = new Customer("Mike Tyson", "mike", "iron123");
            List<Customer> customers = new List<Customer>(){bob, john, mike };
            Orders[] archive = new Orders[1];
            string loggedUser = "";
            List<Product> ShoppingCart = new List<Product>();
            int i = 0;
            Customer tempUserInfo = new Customer();
            tempUserInfo = customers[i];
            string usrInput = "";
            string pwdInput = "";
            decimal code = 0M;
            string userChoice = "";
            int userChoiceToInt = 0;
            string searchOptions = "";
            bool loginIsOk = false;
            bool orderShipped = false;
            bool hasBeenCharged = false;
            string street = "";
            string number = "";
            string city = "";

            try
            {
                while (true)
                {
                    Console.Clear();
                    ShopService.LogIn(ref usrInput, ref pwdInput);

                    if (usrInput != "" && pwdInput != "")
                    {
                        ShopService.LoginCheck(usrInput, pwdInput, ref loginIsOk, customers, ref i, ref loggedUser);
                    }

                    if (loginIsOk == false)
                    {
                        ShopService.BadLoginMsg();
                        Console.ReadKey();

                    }
                    else
                    {
                        if (loginIsOk == true)
                        {
                            while (true)
                            {
                                Console.Clear();
                                ShopService.Menu2(tempUserInfo);
                                CustomException.CheckInput4(ref userChoice, ref userChoiceToInt);
                                Console.Clear();

                                while (true)
                                {
                                    if (userChoiceToInt == 1)
                                    {
                                        Product.ListAllProducts(vendorsDeserialized[0].Products, vendorsDeserialized[1].Products, vendorsDeserialized[2].Products);
                                        ShopService.ExitBack(ref userChoice);
                                        if (userChoice.ToLower() == "e")
                                        {
                                            userChoice = "";
                                            Console.Clear();
                                            break;
                                        }

                                    }

                                    if (userChoiceToInt == 2)
                                    {

                                        while (true)
                                        {
                                            ShopService.Menu3();
                                            CustomException.CheckInput4(ref userChoice, ref userChoiceToInt);
                                            Console.Clear();


                                            if (userChoiceToInt == 1)
                                            {
                                                searchOptions = "";
                                                userChoiceToInt = 0;
                                                Console.Clear();
                                                ShopService.Menu4();
                                                searchOptions = Console.ReadLine();
                                                ShopService.Menu5();
                                                searchOptions += Console.ReadLine();
                                                Vendor.ListVendors(vendorsDeserialized);
                                                searchOptions += Console.ReadLine();
                                                Console.Clear();
                                                Product.DisplayByOptions(searchOptions, vendorsDeserialized);
                                                Console.WriteLine();
                                                Console.WriteLine("Press any key to exit");
                                                Console.ReadKey();
                                                userChoiceToInt = 4;
                                                Console.Clear();
                                            }

                                            if (userChoiceToInt == 2)
                                            {
                                                Console.Clear();
                                                ShopService.Menu4();
                                                searchOptions = Console.ReadLine();
                                                ShopService.Menu5();
                                                searchOptions += Console.ReadLine();
                                                Console.Clear();
                                                Console.WriteLine("Enter the name of the product:");
                                                string searchPorduct = Console.ReadLine();
                                                CustomException.CheckInput2(searchPorduct);
                                                Console.Clear();
                                                Console.WriteLine("Result:");
                                                Product.FindProducts(vendorsDeserialized, searchOptions, searchPorduct);
                                                Console.WriteLine();
                                                Console.WriteLine("Press any key to exit.");
                                                Console.ReadKey();
                                                Console.Clear();
                                            }

                                            if (userChoiceToInt == 4)
                                            {
                                                userChoiceToInt = 2;
                                                break;
                                            }

                                            if (userChoiceToInt == 3)
                                            {
                                                Console.Clear();
                                                break;
                                            }
                                        }

                                        if (userChoiceToInt == 3)
                                        {
                                            userChoiceToInt = 0;
                                            Console.Clear();
                                            break;
                                        }
                                    }

                                    if (userChoiceToInt == 3)
                                    {
                                        Product orderedProduct = new Product();
                                        ShopService.Menu10();
                                        code = decimal.Parse(Console.ReadLine());
                                        Product.FindProduct2(code, vendorsDeserialized, ref orderedProduct);
                                        Console.WriteLine("Enter the quantity:");
                                        orderedProduct.Quantity = int.Parse(Console.ReadLine());
                                        ShoppingCart.Add(orderedProduct);
                                        orderedProduct = null;
                                        Console.WriteLine();
                                        Console.WriteLine("If you want to finish ordering press \"e\", to continue press any other key.");
                                        userChoice = Console.ReadLine();
                                        if (userChoice.ToLower() == "e")
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                        Console.Clear();
                                    }

                                    if (userChoiceToInt == 4 && ShoppingCart.Count != 0)
                                    {
                                        Console.WriteLine("Your shopping cart status:");
                                        Console.WriteLine();
                                        Product.PrintList2(ShoppingCart);
                                        Console.WriteLine();
                                        Console.WriteLine($"Total cost : {Product.TotalCost(ShoppingCart)}");
                                        Console.WriteLine();
                                        Console.WriteLine("If you want to exit press \"e\".");
                                        userChoice = Console.ReadLine();
                                        if (userChoice.ToLower() == "e")
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        if (userChoiceToInt == 4 && ShoppingCart.Count == 0)
                                        {
                                            ShopService.ExitBack2(ref userChoice);
                                            if (userChoice == "e")
                                            {
                                                break;
                                            }
                                        }
                                    }

                                    if (userChoiceToInt == 5 && ShoppingCart.Count != 0)
                                    {
                                        Console.Clear();
                                        if (ShoppingCart.Count != 0)
                                        {
                                            Product.DisplayOrderList(ShoppingCart);
                                            ShopService.Menu6();
                                            userChoice = Console.ReadLine();
                                            Product.DisplayOrderList(ShoppingCart);

                                            if (userChoice != "" && userChoice.All(char.IsDigit))
                                            {
                                                ShoppingCart.RemoveAt(int.Parse(userChoice) - 1);
                                            }
                                        }
                                        else
                                        {
                                            ShopService.Menu11();
                                            userChoice = Console.ReadLine();
                                        }

                                        if (userChoice.ToLower() == "e")
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                        else
                                        {
                                            if (userChoice == "")
                                            {
                                                CustomException.ThrowCustomException();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (userChoiceToInt == 5 && ShoppingCart.Count == 0)
                                        {
                                            ShopService.ExitBack2(ref userChoice);
                                            if (userChoice == "e")
                                            {
                                                break;
                                            }
                                        }
                                    }

                                    if (userChoiceToInt == 6)
                                    {
                                        Console.Clear();
                                        ShopService.Menu7();
                                        CustomException.CheckInput4(ref userChoice, ref userChoiceToInt);
                                        while (true)
                                        {
                                            if (userChoiceToInt == 1 && orderShipped != true && ShoppingCart.Count != 0)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Your shipping address info:");
                                                Console.Write("Street: ");
                                                userChoice = Console.ReadLine();
                                                CustomException.CheckInput2(userChoice);
                                                street = userChoice;
                                                Console.Write("Number: ");
                                                userChoice = Console.ReadLine();
                                                CustomException.CheckInput3(userChoice);
                                                number = userChoice;
                                                ShopService.Menu1();
                                                userChoice = Console.ReadLine();
                                                CustomException.CheckInput3(userChoice);
                                                city = Customer.YourCity(int.Parse(userChoice));
                                                ShopService.Menu8();
                                                userChoice = Console.ReadLine();
                                                CustomException.CheckInput2(userChoice);
                                                userChoiceToInt = int.Parse(userChoice);

                                                if (userChoiceToInt == 1)
                                                {
                                                    ShippingProvider MakedonskaPosta = new ShippingProvider("Makedonska Posta");
                                                    tempUserInfo.Subscribe(MakedonskaPosta);
                                                    Console.Clear();
                                                    MakedonskaPosta.Send(MakedonskaPosta, customers[i].Name, street, number, city);
                                                    orderShipped = true;
                                                    Console.WriteLine();
                                                    Console.WriteLine("Press any key to exit");
                                                    userChoiceToInt = 6;
                                                    Console.ReadKey();
                                                    break;
                                                }
                                                else
                                                {
                                                    if (userChoiceToInt == 2)
                                                    {
                                                        ShippingProvider DELCO = new ShippingProvider("DELCO");
                                                        tempUserInfo.Subscribe(DELCO);
                                                        Console.Clear();
                                                        DELCO.Send(DELCO, customers[i].Name, street, number, city);
                                                        orderShipped = true;
                                                        Console.WriteLine();
                                                        Console.WriteLine("Press any key to exit");
                                                        userChoiceToInt = 6;
                                                        Console.ReadKey();
                                                        break;
                                                    }
                                                }

                                            }

                                            if (userChoiceToInt == 2 && hasBeenCharged != true && orderShipped == true && ShoppingCart.Count != 0)
                                            {
                                                Console.Clear();
                                                ShopService.Menu9();
                                                CustomException.CheckInput4(ref userChoice, ref userChoiceToInt);

                                                if (userChoiceToInt == 1)
                                                {
                                                    Payment creditCard = new Payment("Credit Card");
                                                    tempUserInfo.Subscribe2(creditCard);
                                                    Console.Clear();
                                                    creditCard.Paying(creditCard, "Payment was executed successfully", Product.TotalCost(ShoppingCart));
                                                    Orders order = new Orders();
                                                    order.Customer = customers[i];
                                                    order.Products = ShoppingCart;
                                                    order.Date = DateTime.Now;
                                                    order.TotalAmount = Product.TotalCost2(ShoppingCart);
                                                    string orderLog = Orders.SavingOrder(ref order);
                                                    File.AppendAllText(filePath, orderLog + Environment.NewLine);
                                                    hasBeenCharged = true;
                                                    Console.WriteLine();
                                                    Console.WriteLine("Press \"e\" to exit");
                                                    userChoice = Console.ReadLine();
                                                    if (userChoice.ToLower() == "e")
                                                    {
                                                        order = null;
                                                        ShoppingCart.Clear();
                                                        orderShipped = false;
                                                        hasBeenCharged = false;
                                                        userChoiceToInt = 4;
                                                        Console.Clear();
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        if (userChoice == "")
                                                        {
                                                            CustomException.ThrowCustomException();
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (userChoiceToInt == 2)
                                                    {
                                                        Payment payPal = new Payment("PayPal");
                                                        tempUserInfo.Subscribe2(payPal);
                                                        Console.Clear();
                                                        payPal.Paying(payPal, "Payment was executed successfully", Product.TotalCost(ShoppingCart));
                                                        //Customer.LogOrder(ref historyOfOrders, ShoppingCart);
                                                        //customers[i].OrderHistory = historyOfOrders;
                                                        //List<List<Product>> HistoryOfPurchased = new List<List<Product>>();
                                                        //HistoryOfPurchased = customers[i].Archive;
                                                        //HistoryOfPurchased.Add(ShoppingCart);
                                                        //customers[i].Archive = HistoryOfPurchased;

                                                        Orders order = new Orders();
                                                        order.Customer = customers[i];
                                                        order.Products = ShoppingCart;
                                                        order.Date = DateTime.Now;
                                                        order.TotalAmount = Product.TotalCost2(ShoppingCart);

                                                        string orderLog = Orders.SavingOrder(ref order);

                                                        File.AppendAllText(filePath, orderLog + Environment.NewLine);

                                                        hasBeenCharged = true;
                                                        Console.WriteLine();
                                                        Console.WriteLine("Press \"e\" to exit");
                                                        userChoice = Console.ReadLine();
                                                        if (userChoice.ToLower() == "e")
                                                        {
                                                            order = null;
                                                            //Test code
                                                            ShoppingCart.Clear();
                                                            orderShipped = false;
                                                            hasBeenCharged = false;
                                                            //End of test code
                                                            userChoiceToInt = 4;
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            if (userChoice == "")
                                                            {
                                                                CustomException.ThrowCustomException();
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (userChoiceToInt != 4 && userChoiceToInt != 3 && hasBeenCharged != true && orderShipped != true)
                                                {
                                                    Console.Clear();
                                                    ShopService.Menu12();
                                                    Console.ReadKey();
                                                    userChoiceToInt = 6;
                                                    break;
                                                }
                                            }

                                            if ((orderShipped == true || hasBeenCharged == true) && userChoiceToInt != 4)
                                            {
                                                if (orderShipped == true && hasBeenCharged == false && ShoppingCart.Count != 0)
                                                {
                                                    Console.Clear();
                                                    ShopService.Menu13();
                                                    Console.WriteLine();
                                                    Console.ReadKey();
                                                    userChoiceToInt = 6;
                                                    break;
                                                }
                                                else
                                                {
                                                    if (orderShipped == false && hasBeenCharged == true)
                                                    {
                                                        Console.Clear();
                                                        ShopService.Menu14();
                                                        Console.WriteLine();
                                                        Console.ReadKey();
                                                        userChoiceToInt = 6;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        Console.Clear();
                                                        ShopService.Menu15();
                                                        Console.WriteLine();
                                                        Console.ReadKey();
                                                        userChoiceToInt = 6;
                                                        break;
                                                    }
                                                }
                                            }

                                            if (userChoiceToInt == 3)
                                            {
                                                Console.Clear();
                                                ShopService.Menu16();
                                                userChoice = Console.ReadLine();
                                                CustomException.CheckInput3(userChoice);
                                                userChoiceToInt = int.Parse(userChoice);

                                                if (userChoiceToInt == 1)
                                                {
                                                    Console.Clear();
                                                    Orders.PrintOrderHistory("$", filePath, loggedUser);
                                                    Console.WriteLine("Press any key to exit...");
                                                    Console.ReadKey();
                                                    userChoiceToInt = 4;
                                                    break;
                                                }
                                                else
                                                {
                                                    if (userChoiceToInt == 2)
                                                    {
                                                        Console.Clear();
                                                        Orders.PrintOrderHistory("#", filePath, loggedUser);
                                                        Console.WriteLine("Press any key to exit...");
                                                        Console.ReadKey();
                                                        userChoiceToInt = 4;
                                                        break;
                                                    }
                                                }
                                            }

                                            if (userChoiceToInt == 4)
                                            {
                                                Console.Clear();
                                                break;
                                            }
                                        }
                                        if (userChoiceToInt == 4)
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        if (userChoiceToInt == 6 && ShoppingCart.Count == 0)
                                        {
                                            ShopService.ExitBack2(ref userChoice);
                                            if (userChoice == "e")
                                            {
                                                break;
                                            }
                                        }
                                    }

                                    if (userChoiceToInt == 7)
                                    {
                                        loggedUser = "";
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (CustomException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.HelpLink);
                Console.WriteLine(ex.StackTrace);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            Console.ReadLine();
        }
    }
}