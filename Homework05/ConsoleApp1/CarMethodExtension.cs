using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class CarMethodExtension
    {
        public static void Drive(this Car car, string place)
        {
            if (car.IsDrivable)
            {
                car.Fuel -= 30;
                Console.WriteLine($"The {car.Brand} is heading towards {place}.");
            }
            else
            {
                if(car.IsDrivable == false)
                {
                    Console.WriteLine("The car can't be driven, you can't reach to your destination");
                }
            }
        }

        public static string GetCarStats(this Car car)
        {
            return $"Car's info:\n" +
                   $"Blarnd: {car.Brand}\n" +
                   $"Model: {car.Model}\n" +
                   $"Color: {car.Color}\n" +
                   $"Driving status: {(car.IsDrivable ? "The car is in drivable condition" : "The car has flat tire/s")}";
        }
    }
}
