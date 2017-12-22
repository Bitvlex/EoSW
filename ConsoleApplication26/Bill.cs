using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication26
{
    public class Bill
    {
        private List<Item> _items;
        private Customer _customer;
        public double f;
        public double bonus;
        public string result;
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
        public double GetSum(Item each)
        {
            double sum = each.getQuantity() * each.getPrice();
            return sum;
        }
        public string ReturnInfo(double amount, double bonuses)
        {
            string info = "Сумма счета составляет " + amount.ToString() + "\n" + "Вы заработали " + bonuses.ToString() + " бонусных балов";
            return info;
        }
        public double UsingBonuses(Item each)
        {
            double discount = 0;
            if ((each.getGoods().getPriceCode() == Goods.REGULAR) && each.getQuantity() > 5)
            {
                discount += _customer.useBonus((int)(GetSum(each)));
            }
            if ((each.getGoods().getPriceCode() == Goods.SPECIAL_OFFER) && each.getQuantity() > 1)
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
        public int Get_Bonuses(Item each)
        {
            int bonuses = 0;

            switch (each.getGoods().getPriceCode())
            {
                case Goods.REGULAR:
                    if (each.getQuantity() > 2)
                    {
                        bonuses = (int)(GetSum(each) * 0.05);
                    }
                    break;
                case Goods.SALE:
                    if (each.getQuantity() > 3)
                    {
                        bonuses = (int)(GetSum(each) * 0.01);
                    }
                    break;
            }
            return bonuses;
        }
        public double Get_Discount(Item each)
        {
            double discount = 0;
            switch (each.getGoods().getPriceCode())
            {
                case Goods.REGULAR:
                    if (each.getQuantity() > 2)
                    {
                        discount = (GetSum(each)) * 0.03;
                    }
                break;
                case Goods.SPECIAL_OFFER:
                    if (each.getQuantity() > 10)
                    {
                        discount = (GetSum(each)) * 0.005;
                    }
                break;
                case Goods.SALE:
                    if (each.getQuantity() > 3)
                    {
                        discount = (GetSum(each)) * 0.01;
                    }
                break;
            }
            return discount;
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
                discount = Get_Discount(each);
                bonus = Get_Bonuses(each);                
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
