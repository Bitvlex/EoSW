using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication27
{
    public class Customer
    {
        private double bonus;
        private String name;
        public Customer(String name, double bonus)
        {
            this.name = name;
            this.bonus = bonus;
        }
        public String getName()
        {
            return name;
        }
        public double getBonus()
        {
            return bonus;
        }
        public void receiveBonus(double bonus)
        {
            this.bonus = bonus;
        }
        public double useBonus(double needBonus)
        {
            double bonusTaken;
            if (needBonus > bonus)
            {
                bonusTaken = bonus;
                bonus = 0;
            }
            else
            {
                bonusTaken = needBonus;
                bonus = bonus - needBonus;
            }
            return bonusTaken;
        }
    }
}