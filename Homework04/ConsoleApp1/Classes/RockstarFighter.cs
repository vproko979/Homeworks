using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Classes
{
    public class RockstarFighter : Fighter, IStreet, IBox, IMuayThai
    {
        public int Reputation { get; set; }

        public RockstarFighter(double health, double powerPunch, double speed, int reputation) : base(health, powerPunch, speed)
        {
            Reputation = reputation;
        }

        public void DoStreet(Fighter opponent)
        {
            opponent.TakeDamage(2 * Reputation * PowerPunch * Speed);
            IsItReadyToFinish(opponent);
        }

        public void DoBoxing(Fighter opponent)
        {
            opponent.TakeDamage(3 * Reputation * PowerPunch * Speed);
            IsItReadyToFinish(opponent);
        }

        public void DoMuayThai(Fighter opponent)
        {
            opponent.TakeDamage(4 * Reputation * PowerPunch * Speed);
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
            Console.WriteLine("The opponent was finished with a fatal combination of punches, elbows and leg kicks. His recovery period gonna last 1-3 weeks.");
        }
    }
}
