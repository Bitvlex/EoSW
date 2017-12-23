using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication27
{
    public class Regular : Goods
    {
        public Regular(string name) : base(name)
        {

        }
        public override double GetSum(Item each)
        {
            double sum = each.getQuantity() * each.getPrice();
            return sum;
        }
        public override int Get_Bonuses(Item each)
        {
            int bonuses = 0;
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
        public override double Get_Discount(Item each)
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
