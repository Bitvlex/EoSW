using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication27
{
    public class Special : Goods
    {
        IStrategy _strategy;
        public Special(string id, string name, IStrategy strategy) : base(name, strategy)
        {
            this._strategy = strategy;
        }
        public override double GetSum(Item each)
        {
            double sum = each.getQuantity() * each.getPrice();
            return sum;
        }
        public override double Get_Bonuses(Item each)
        {
            if (_strategy is bonusStrategy)
            {
                return _strategy.Algorithm(each);
            }
            else
            {
                double bonuses = 0;
                if (each.getQuantity() > 2)
                {
                    bonuses = (int)(GetSum(each) * 0.05);
                }
                if (each.getQuantity() > 3)
                {
                    bonuses = (int)(GetSum(each) * 0.01);
                }
                return bonuses;
            }
        }
        public override double Get_Discount(Item each)
        {
            if (_strategy is discountStrategy)
            {
                return _strategy.Algorithm(each);
            }
            else
            {
                double discount = 0;
                if (each.getQuantity() > 2)
                {
                    discount = GetSum(each) * 0.03;
                }
                if (each.getQuantity() > 10)
                {
                    discount = GetSum(each) * 0.005;
                }
                if (each.getQuantity() > 3)
                {
                    discount = GetSum(each) * 0.01;
                }
                return discount;
            }
        }
    }
}
