using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Classes
{
    public abstract class Fighter
    {
        private double Health { get; set; }
        protected virtual double PowerPunch { get; set; }
        protected virtual double Speed { get; set; }

        public Fighter(double health, double powerPunch, double speed)
        {
            Health = health;
            PowerPunch = powerPunch;
            Speed = speed;
        }

        // Takes an amount of damage from an opponent
        public virtual void TakeDamage(double damage)
        {
            Health -= damage;
        }

        // Takes all the damage from an opponent
        public virtual void TakeDamage()
        {
            Health = 0;
        }

        // Checks if opponent is dizzy, if he is then Finisher method should be called.
        public virtual bool IsDizzy()
        {
            if (Health < 10)
            {
                return true;
            }
            return false;
        }

        public abstract void IsItReadyToFinish(Fighter opponent);

        protected abstract void Finisher(Fighter opponent);
    }
}
