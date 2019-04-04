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

        partial void StartCar()
        {
            Console.WriteLine("The car's engine has started, the car is in motion.");
            IsDrivable = true;
        }

        partial void StartLights()
        {
            Console.WriteLine("Car's headlights are turned on.");
        }
    }
}
