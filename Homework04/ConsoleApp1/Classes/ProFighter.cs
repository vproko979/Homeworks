using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Classes
{
    public class ProFighter : Fighter, IStreet, IBox
    {
        public int Experience { get; set; }

        public ProFighter(double health, double powerPunch, double speed, int experience) : base(health, powerPunch, speed)
        {
            Experience = experience;
        }

        public void DoStreet(Fighter opponent)
        {
            opponent.TakeDamage(2 * Experience);
        }

        public void DoBoxing(Fighter opponent)
        {
            opponent.TakeDamage(3 * Experience);
        }

        public override void IsItReadyToFinish(Fighter opponent)
        {
            if (opponent.IsDizzy())
            {
                Finisher(opponent);
            }
        }

        protected override void Finisher(Fighter opponent)
        {
            opponent.TakeDamage();
            Console.WriteLine("The opponent was finished with a combination of jabs, hooks and uppercuts. His recovery period gonna last 3-5 weeks.");
            
        }
    }
}
