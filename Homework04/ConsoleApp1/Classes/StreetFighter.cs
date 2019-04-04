using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Classes
{
    public class StreetFighter : Fighter, IStreet
    {
        public int StreetCredit { get; set; }

        public StreetFighter(double health, double powerPunch, double speed, int streetCredit) : base(health, powerPunch, speed)
        {
            StreetCredit = streetCredit;
        }

        public void DoStreet(Fighter opponent)
        {
            opponent.TakeDamage(2 * StreetCredit * PowerPunch * Speed);
            IsItReadyToFinish(opponent);
        }

        public override void IsItReadyToFinish(Fighter opponent)
        {
            if (opponent.IsDizzy())
            {
                Finisher(opponent);
            }
            else
            {
                if (opponent.IsDizzy() != true)
                {
                    Console.WriteLine("The opponent was heavily beaten, but he still managed to survive this battle.");
                }
            }
        }

        protected override void Finisher(Fighter opponent)
        {
            opponent.TakeDamage();
            Console.WriteLine("The opponent was finished with a burst of uncontrollable punches. His recovery period gonna last 5-7 weeks.");
        }
    }
}
