using ConsoleApp1.Classes;
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

            StreetFighter mess = new StreetFighter(120, 2, 1, 7);
            ProFighter ryu = new ProFighter(150, 4, 2, 13);
            RockstarFighter blanka = new RockstarFighter(170, 5, 4, 17);

            ryu.DoBoxing(mess);
            ryu.DoStreet(mess);
            ryu.DoBoxing(mess);
            ryu.DoStreet(mess);
            ryu.IsItReadyToFinish(mess);
            blanka.DoBoxing(ryu);
            blanka.DoMuayThai(ryu);
            blanka.DoStreet(ryu);
            blanka.IsItReadyToFinish(ryu);

            Console.ReadLine();

        }
    }
}
