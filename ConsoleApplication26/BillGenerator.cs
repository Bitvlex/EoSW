using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication27
{
    public class BillGenerator
    {
        private List<Item> _items;
        private Customer _customer;
        public double f;
        public double bonus;
        public string result;
        IPresenter p;
        public double GetSum(Item each)
        {
            double sum = each.getQuantity() * each.getPrice();
            return sum;
        }
        public BillGenerator(Customer customer, IPresenter p)
        {
            this._customer = customer;
            this._items = new List<Item>();
            this.p = p;
        }
        public void addGoods(Item arg)
        {
            _items.Add(arg);
        }
        public double UsingBonuses(Item each)
        {
            double discount = 0;
            if (each.getGoods().GetType() == typeof(Regular) && each.getQuantity() > 5)
            {
                discount += _customer.useBonus((int)(GetSum(each)));
            }
            if (each.getGoods().GetType() == typeof(Special) && each.getQuantity() > 1)
            {
                discount = _customer.useBonus((int)(GetSum(each)));
            }
            return discount;
        }
        public String GenerateBill()
        {
            double totalAmount = 0;
            int totalBonus = 0;
            List<Item>.Enumerator items = _items.GetEnumerator();
            result = p.GetHeader(_customer);
            while (items.MoveNext())
            {
                double discount = 0;
                int bonus = 0;
                Item each = (Item)items.Current;

                discount = each.GetDiscount();
                bonus = each.GetBonus();

                double thisAmount = each.getQuantity() * each.getPrice();

                discount += UsingBonuses(each);

                thisAmount = each.getQuantity() * each.getPrice() - discount;

                result += p.Showing_result(thisAmount, discount, bonus, each);
                totalAmount += thisAmount;
                totalBonus += bonus;
            }
            result = result + p.GetFooter(totalAmount, totalBonus);

            f = Convert.ToDouble(totalAmount);
            bonus = Convert.ToDouble(totalBonus);

            _customer.receiveBonus(totalBonus);
            return result;
        }
    }
}