using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public partial class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Fuel { get; set; }
        public int MaxFuel { get; set; }
        public bool HaveKeys { get; set; }
        public bool IsDrivable { get; set; }

        partial void StartCar();

        partial void StartLights();
    }
}
