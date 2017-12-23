using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.ComponentModel;

namespace ConsoleApplication27
{
    public class discountStrategy : IStrategy
    {

        private int count = 0;
        private double t = 0;
        public discountStrategy(int count, double t)
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
            double discount = 0;
            if (count > 2)
            {
                discount = GetSum(each) * t;
            }
            return discount;
        }
    }
}
