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
            Random random = new Random();
            int randomNumber = random.Next(car.MaxFuel - car.Fuel);

            if (car.Fuel + randomNumber >= car.MaxFuel)
            {
                car.Fuel = car.MaxFuel;
                Console.WriteLine($"{car.Brand} reservoir is full to the top.");
            }
            else if (car.Fuel + randomNumber < car.MaxFuel)
            {
                car.Fuel += randomNumber;
                Console.WriteLine($"The {car.Brand} was filled with {randomNumber} liters of fuel.");
            }
            
        }

        public static void PumpUpTires(Car car)
        {
            Console.WriteLine($"{car.Brand} tires are inflated, you can drive the car now");
            car.IsDrivable = true;
        }
    }
}
