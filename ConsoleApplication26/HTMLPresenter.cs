using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication27
{
    public class HTMLPresenter : IPresenter
    {
        public string GetHeader(Customer _customer)
        {
            string result = "Счет для " + _customer.getName() + "\n" + "\t" + "Название" + "\t" + "Цена" + "\t" + "Кол-во" + "Стоимость" + "\t" + "Скидка" + "\t" + "Сумма" + "\t" + "Бонус" + "\n";
            return result;
        }
        public string GetFooter(double amount, double bonuses)
        {
            string info = "Сумма счета составляет " + amount.ToString() + "\n" + "Вы заработали " + bonuses.ToString() + " бонусных балов";
            return info;
        }
        public string Showing_result(double thisAmount, double discount, double bonus, Item each)
        {
            string result = null;
            result = "\t" + each.getGoods().getTitle() + "\t" + "\t" + each.getPrice() + "\t" + each.getQuantity() + "\t" + (each.getQuantity() * each.getPrice()).ToString() + "\t" + discount.ToString() + "\t" + thisAmount.ToString() + "\t" + bonus.ToString() + "\n";
            return result;
        }
    }
}