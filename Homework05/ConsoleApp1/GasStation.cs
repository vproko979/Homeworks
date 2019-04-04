using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class GasStation
    {
        public static void Refill(Car car)
        {
            Console.WriteLine("Car's reservoir is full to the top.");
            car.Fuel = car.MaxFuel;
        }

        public static void PumpUpTires(Car car)
        {
            Console.WriteLine("Car's tires are inflated.");
            car.IsDrivable = true;
        }
    }
}
