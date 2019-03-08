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
            //Exercise 4

            DateTime todaysDate = DateTime.Now;
            DateTime threeDaysFromNow = DateTime.Now.AddDays(3);
            DateTime oneMonthFromNow = DateTime.Now.AddMonths(1);
            DateTime oneMonth3DaysFromNow = DateTime.Now.AddMonths(1).AddDays(3);
            DateTime oneYear2MonthsAgo = DateTime.Now.AddYears(-1).AddMonths(-2);
            Console.WriteLine("Three days from today: " + threeDaysFromNow);
            Console.WriteLine("The date one month from now will be: {0:dddd/MMMM/yyyy}", oneMonthFromNow);
            Console.WriteLine("The date one month and three days from now will be: {0:dddd/MMMM/yyyy}", oneMonth3DaysFromNow);
            Console.WriteLine("The date one year and two months ago was: {0:dddd/MMMM/yyyy}", oneYear2MonthsAgo);
            Console.WriteLine("The current month is {0:MMMM}.", todaysDate);
            Console.WriteLine("The current year is {0:yyyy}.", todaysDate);

            //Exercise 5

            Console.Write(@"Please enter your birth date in this format year/month/day (e.g. 2019,01,31)): ");
            DateTime usersBirthDate = DateTime.Parse(Console.ReadLine());
            int years = AgeCalculator(usersBirthDate);
            if (years < 1)
            {
                Console.WriteLine("You're less than a year old.");
            }
            else
            {
                Console.WriteLine("You're " + years + " old.");
            }

            Console.ReadLine();
        }

        public static int AgeCalculator(DateTime birthDate)
        {
            DateTime todaysDate = DateTime.Now;
            double result = (todaysDate - birthDate).TotalDays;
            int years = Convert.ToInt32(result) / 365;

            if (todaysDate.Month == birthDate.Month && todaysDate.Day == birthDate.Day)
            {
                Console.WriteLine("Your birthday is today. Happy Birthday!");
            }
            if (todaysDate.Month == birthDate.Month && birthDate.Day - todaysDate.Day == 1)
            {
                Console.WriteLine("Your birthday is tomorrow. Enjoy your day tomorrow.");
            }
            if (todaysDate.Month == birthDate.Month && birthDate.Day - todaysDate.Day == -1)
            {
                Console.WriteLine("Your birthday was yesterday. Happy Birthday!");
            }
            return years;
        }
    }
}
