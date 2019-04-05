using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public partial class Car
    {
        public Car(string brand, string model, string color, int fuel, bool haveKeys, bool isDrivable)
        {
            Brand = brand;
            Model = model;
            Color = color;
            Fuel = fuel;
            MaxFuel = fuel;
            HaveKeys = haveKeys;
            IsDrivable = isDrivable;
        }

        public void StartCar()
        {
            if (IsDrivable == true && Fuel > 0)
            {
                Console.WriteLine("The car's engine has started, the car is in motion.");
            }
            else if (IsDrivable == false && Fuel > 0)
            {
                Console.WriteLine("You have petrol, but it seems you got a flat tire, pump/change your tire");
            }else if (IsDrivable == true && Fuel == 0)
            {
                Console.WriteLine("Car reservoir is empty, you should visit a gas station");
            }
        }

        public void StartLights()
        {
            if (HaveKeys == true)
            {
                Console.WriteLine("Lights on the dashboard turns on.");
            }
        }

        public static void GetCarStats(Car car)
        {
           Console.WriteLine($"Car's info:\n" +
                   $"Blarnd: {car.Brand}\n" +
                   $"Model: {car.Model}\n" +
                   $"Color: {car.Color}");
        }
    }
}
