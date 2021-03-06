using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car("Volvo", "XC40", "White", 179, true, true);
            Car car2 = new Car("Volkswagen", "Polo", "Red", 120, false, false);
            Car car3 = new Car("Honda", "Civic", "Red", 0, false, true);
            Car car4 = new Car("Audi", "Q8", "Red", 310, false, false);

            Car.GetCarStats(car1);
            Console.WriteLine();
            Console.WriteLine("Fuel before driving " + car1.Fuel);
            Console.WriteLine("----------------------------------");
            car1.Drive("Center");
            Console.WriteLine("After arriving to its destination.");
            Console.WriteLine("Fuel after driving " + car1.Fuel);
            Console.WriteLine("----------------------------------");
            Console.WriteLine("The car is refilling");
            GasStation.Refill(car1);
            Console.WriteLine("Fuel " + car1.Fuel);
            Console.WriteLine("----------------------------------");
            Car.GetCarStats(car2);
            Console.WriteLine();
            car2.Drive("Downtown");
            Console.WriteLine("Car2 fuel is " + car2.Fuel);
            Console.WriteLine("----------------------------------");
            GasStation.PumpUpTires(car2);
            car2.Drive("Downtown");
            Console.WriteLine("Car2 fuel before refilling: " + car2.Fuel);
            Console.WriteLine("----------------------------------");
            GasStation.Refill(car2);
            Console.WriteLine("Car2 fuel after refilling: " + car2.Fuel);
            Console.WriteLine();
            car3.StartCar();
            car3.Drive("Center");
            car4.StartCar();
            car4.Drive("Center");


            Console.ReadLine();
        }
    }
}
