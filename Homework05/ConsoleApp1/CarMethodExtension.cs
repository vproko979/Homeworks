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
            Random random = new Random();
            int randomNumber = random.Next(0, car.MaxFuel);

            if (car.IsDrivable && car.Fuel > 0)
            {
                if (car.Fuel - randomNumber <= 0)
                {
                    car.Fuel = 0;
                }
                else
                {
                    car.Fuel -= randomNumber;
                }
                Console.WriteLine($"The {car.Brand} is heading towards {place}.");
            }
            else
            {
                if(car.IsDrivable == false || car.Fuel == 0)
                {
                    Console.WriteLine($"The {car.Brand} can't be driven, you can't reach to your destination");
                }
            }
        }
    }
}
