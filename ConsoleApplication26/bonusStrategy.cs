using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ConsoleApplication27
{
    public class bonusStrategy : IStrategy
    {
        private int count = 0;
        private double t = 0;
        public bonusStrategy(int count, double t)
        {
            this.count = count;
            this.t = t;
        }
        public double GetSum(Item each)
        {
            double sum = each.getQuantity() * each.getPrice();
            return sum;
        }
        public double Algorithm(Item each)
        {
            int bonuses = 0;
            if (count > 2)
            {
                bonuses = (int)(GetSum(each) * t);
            }
            return bonuses;
        }
    }
}