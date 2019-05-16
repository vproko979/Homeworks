using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class CustomException : Exception
    {
        public string CustomDescription { get; set; }
        public CustomException() : base()
        {

        }
        public CustomException(string message) : base(message)
        {

        }

        public static void ThrowCustomException()
        {
            CustomException customException = new CustomException("ERROR:You've have entered incorrect value/character.\n" +
                                                                  "If you need help, use the link below:");
            customException.HelpLink = "https://www.e-shop.com/support.html";
            throw customException;
        }
        public static void CheckInput1(string userChoice)
        {
            if (userChoice == "" || !userChoice.Replace(" ", "").All(char.IsLetter))
            {
                ThrowCustomException();
            }
        }

        public static void CheckInput2(string userChoice)
        {
            if (userChoice == "" || !userChoice.Replace(" ", "").All(char.IsLetterOrDigit))
            {
                ThrowCustomException();
            }
        }
        public static void CheckInput3(string userChoice)
        {
            if (userChoice == "" || !userChoice.Replace(" ", "").All(char.IsDigit))
            {
                ThrowCustomException();
            }
        }

        public static void CheckInput4(ref string userChoice, ref int userChoiceToInt)
        {
            userChoice = Console.ReadLine();
            CustomException.CheckInput3(userChoice);
            userChoiceToInt = int.Parse(userChoice);
        }
    }
}
