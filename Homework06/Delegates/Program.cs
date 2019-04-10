using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {

            //Task 1
            #region Mediums
            Medium cnn = new Medium();
            Medium a1 = new Medium();
            #endregion

            #region Followers
            Follower john = new Follower("John");
            Follower zvonko = new Follower("Zvonko");
            Follower zivko = new Follower("Zivko");
            #endregion

            #region Subscriptions
            john.Subscribe(cnn);
            john.Subscribe(a1);

            zvonko.Subscribe(a1);

            zivko.Subscribe(cnn);
            #endregion

            #region SendingNews
            cnn.SendBreakingNews("Man died eating", "lorem ipsum...", DateTime.Now);
            a1.SendBreakingNews("Cat bitten by a spider, looks like a ballon", "lorem ipsum...", DateTime.Now);
            #endregion


            //Task 2

            GenericList<int> myArray = new GenericList<int>();

            myArray.Add(1);
            myArray.Add(2);
            myArray.Add(3);
            myArray.Add(4);
            myArray.Add(5);
            myArray.Add(6);
            myArray.Add(7);
            
            myArray.DisplayValues();

            Console.WriteLine($"Array's length is {myArray.Count}");

            Console.WriteLine($"Array's value at index 6 is \"{myArray[6]}\"");

            Console.WriteLine($"Removed value at index 2 is \"{myArray.Remove(2)}\"");

            myArray.DisplayValues();
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };
            Console.WriteLine(numbers[2]);
            Console.ReadLine();
        }
    }
}
