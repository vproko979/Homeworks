using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            //TASK 1
            
            //Exercise 5

            //int[] sumNumbers = new int[5];
            //int counter = 0;

            //while (counter < 5)
            //{
            //    Console.Write("Please enter a number: ");
            //    int userInput = int.Parse(Console.ReadLine());
            //    sumNumbers[counter] = userInput;
            //    if (counter < sumNumbers.Length - 1)
            //    {
            //        Console.WriteLine("You need to enter " + (5 - (counter + 1)) + " more number/s.");
            //    }
            //    counter++;
            //}

            //int sum = 0;

            //foreach (int number in sumNumbers)
            //{
            //    sum += number;
            //}

            //Console.WriteLine("The sum of all numbers you have enterd is " + sum);
            //Console.ReadLine();



            //Exercise 6

            //string[] names = new string[5];
            //int counter = 0;

            //while (counter < 5)
            //{
            //    Console.Write("Please enter an name: ");
            //    string name = Console.ReadLine();
            //    names[counter] = name;
            //    if (counter < names.Length - 1)
            //    {
            //        Console.WriteLine("You need to enter " + (5 - (counter + 1)) + " more name/s.");
            //    }
            //     counter++;
            //}

            //string result = "";

            //foreach (string name in names)
            //{
            //    result += name + " ";
            //}

            //Console.WriteLine("The names you've entered: " + result);
            //Console.ReadLine();

            //TASK 2 and 3

            int[] integers = new int[20];

            int counter = 0;

            while (counter < 20)
            {
                Console.Write("Enter an number: ");
                int userInput = int.Parse(Console.ReadLine());
                integers[counter] = userInput;
                if (counter < integers.Length - 1)
                    Console.WriteLine("You need to enter " + (20 - (counter + 1)) + " more number/s.");
                counter++;
            }

            foreach (int integer in integers)
            {
                if (integer == 0)
                    Console.WriteLine("Skipped");
                else if (integer.ToString().Length == 3)
                    break;
                else
                    Console.WriteLine(integer);
            }

            Console.ReadLine();
        }
    }
}
