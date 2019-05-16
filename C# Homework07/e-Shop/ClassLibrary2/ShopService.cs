using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public static class ShopService
    {
        public static void LogIn(ref string usrInput, ref string pwdInput)
        {
            Console.WriteLine("Welcome to our online shop.");
            Console.WriteLine();
            Console.WriteLine("Login");
            Console.WriteLine();
            Console.Write("Username:");
            usrInput = Console.ReadLine();
            CustomException.CheckInput2(usrInput);
            Console.Write("Password:");
            pwdInput = Console.ReadLine();
            CustomException.CheckInput2(pwdInput);
        }

        public static void LoginCheck(string user, string pass, ref bool loginIsOk, List<Customer> customers, ref int i, ref string loggedUser)
        {
            foreach (Customer customer in customers)
            {
                if (customer.Username == user && customer.Password == pass)
                {
                    loginIsOk = true;
                    loggedUser = customer.Name;
                    i = customers.FindIndex(a => a.Username == user);
                    return;
                }
            }
            loginIsOk = false;
            return;
        }

        public static void BadLoginMsg()
        {
            Console.Clear();
            Console.WriteLine("Either your username, or password was wrong.");
            Console.WriteLine("Press any key, and try again.");
            Console.WriteLine();
        }

        public static void Menu1()
        {
            Console.WriteLine("Choose shipping place:");
            Console.WriteLine();
            Console.WriteLine("1) Skopje");
            Console.WriteLine("2) Bitola");
            Console.WriteLine("3) Ohrid");
            Console.WriteLine("4) Stip");
        }

        public static void Menu2( Customer customer)
        {
            Console.WriteLine($"Welcome {customer.Name}");
            Console.WriteLine();
            Console.WriteLine("Shopping menu:");
            Console.WriteLine();
            Console.WriteLine("1) The whole list of products");
            Console.WriteLine("2) Search the product catalog");
            Console.WriteLine("3) Create new order");
            Console.WriteLine("4) Check your shopping cart");
            Console.WriteLine("5) Remove an existing order");
            Console.WriteLine("6) Finalize your order");
            Console.WriteLine("7) Exit");
        }

        public static void Menu3()
        {
            Console.WriteLine("1) Serach products by vendors");
            Console.WriteLine("2) Serach by product name");
            Console.WriteLine("3) Back to main menu");
        }

        public static void Menu4()
        {
            Console.Clear();
            Console.WriteLine("Sort by:");
            Console.WriteLine();
            Console.WriteLine("1) Name");
            Console.WriteLine("2) Price");
        }

        public static void Menu5()
        {
            Console.Clear();
            Console.WriteLine("Sort order:");
            Console.WriteLine();
            Console.WriteLine("1) Ascending");
            Console.WriteLine("2) Descending");
        }

        public static void Menu6()
        {
            Console.WriteLine("Enter order's number to remove that oreder");
            Console.WriteLine();
            Console.WriteLine("If you want to exit press \"e\".");
        }

        public static void Menu7()
        {
            Console.WriteLine("1) Select shipping provider");
            Console.WriteLine("2) Select your payment method");
            Console.WriteLine("3) Order history");
            Console.WriteLine("4) Exit");
        }

        public static void Menu8()
        {
            Console.WriteLine("Choose shipping provider:");
            Console.WriteLine();
            Console.WriteLine("1) Makedonska posta");
            Console.WriteLine("2) DELCO");
            Console.WriteLine();
            Console.WriteLine("If you want to exit press \"e\".");
        }

        public static void Menu9()
        {
            Console.WriteLine("Choose your payment type:");
            Console.WriteLine();
            Console.WriteLine("1) Pay with credit card");
            Console.WriteLine("2) Pay with PayPal");
            Console.WriteLine("3) Exit");
        }

        public static void Menu10()
        {
            Console.WriteLine("Make order.");
            Console.WriteLine();
            Console.WriteLine("Enter product's code:");
        }

        public static void Menu11()
        {
            Console.WriteLine("You don't have orders");
            Console.WriteLine();
            Console.WriteLine("If you want to exit press \"e\".");
        }

        public static void Menu12()
        {
            Console.WriteLine("Choose your shipping provider, before you pay.");
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
        }

        public static void Menu13()
        {
            Console.WriteLine("Shipping provider has been already chosen");
            Console.WriteLine("Press any key to exit");
        }

        public static void Menu14()
        {
            Console.WriteLine("Your payment has been already processed");
            Console.WriteLine("Press any key to exit");
        }

        public static void Menu15()
        {
            Console.WriteLine("Shipping provider has been already chosen");
            Console.WriteLine("Your payment has been already processed");
            Console.WriteLine("Press any key to exit");
        }

        public static void Menu16()
        {
            Console.WriteLine("Order history:");
            Console.WriteLine();
            Console.WriteLine("1) Orders over 1000 MKD");
            Console.WriteLine("2) Orders belov 1000 MKD");
            Console.WriteLine();
            Console.WriteLine("Press \"e\" to exit");
        }

        public static void ExitBack(ref string userChoice)
        {
            Console.WriteLine();
            Console.WriteLine("Press \"e\" to exit.");
            userChoice = Console.ReadLine();
            CustomException.CheckInput1(userChoice);
        }

        public static void ExitBack2(ref string userChoice)
        {
            Console.WriteLine("Your list with products is empty");
            Console.WriteLine("Press \"e\" to exit");
            userChoice = Console.ReadLine();
        }        

    }
}
