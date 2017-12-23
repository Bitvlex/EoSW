using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication27
{
    public class Bill
    {
        private List<Item> _items;
        private Customer _customer;
        public double f;
        public double bonus;
        public string result;
        public double GetSum(Item each)
        {
            double sum = each.getQuantity() * each.getPrice();
            return sum;
        }
        public Bill(Customer customer)
        {
            this._customer = customer;
            this._items = new List<Item>();
        }
        public void addGoods(Item arg)
        {
            _items.Add(arg);
        }
        public string GetHeader()
        {
            string result = "Счет для " + _customer.getName() + "\n" + "\t" + "Название" + "\t" + "Цена" + "\t" + "Кол-во" + "Стоимость" + "\t" + "Скидка" + "\t" + "Сумма" + "\t" + "Бонус" + "\n";
            return result;
        }
        public string ReturnInfo(double amount, double bonuses)
        {
            string info = "Сумма счета составляет " + amount.ToString() + "\n" + "Вы заработали " + bonuses.ToString() + " бонусных балов";
            return info;
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
        public string Showing_result2(double thisAmount, double discount, double bonus, Item each)
        {
            string result = null;
            result = "\t" + each.getGoods().getTitle() + "\t" + "\t" + each.getPrice() + "\t" + each.getQuantity() + "\t" + (each.getQuantity() * each.getPrice()).ToString() + "\t" + discount.ToString() + "\t" + thisAmount.ToString() + "\t" + bonus.ToString() + "\n";
            return result;
        }

        public String statement()
        {
            double totalAmount = 0;
            int totalBonus = 0;
            List<Item>.Enumerator items = _items.GetEnumerator();
            result = GetHeader();
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

                result += Showing_result2(thisAmount, discount, bonus, each);
                totalAmount += thisAmount;
                totalBonus += bonus;
            }
            result = result + ReturnInfo(totalAmount, totalBonus);

            f = Convert.ToDouble(totalAmount);
            bonus = Convert.ToDouble(totalBonus);

            _customer.receiveBonus(totalBonus);
            return result;
        }
    }
}

