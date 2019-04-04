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
            if (IsDrivable == true)
            {
                Console.WriteLine("The car's engine has started, the car is in motion.");
            }
        }

        public void StartLights()
        {
            if (HaveKeys == true)
            {
                Console.WriteLine("Lights on the dashboard turns on.");
            }
        }

        public void GetCarStats()
        {
           Console.WriteLine($"Car's info:\n" +
                   $"Blarnd: {Brand}\n" +
                   $"Model: {Model}\n" +
                   $"Color: {Color}\n" +
                   $"Driving status: {(IsDrivable ? "The car is in drivable condition" : "The car has flat tire/s")}");
        }
    }
}
