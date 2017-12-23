using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication27
{
    public class Goods
    {
        protected String _title;
        protected int _priceCode;
        public virtual double GetSum(Item each)
        {
            return 0;
        }
        public virtual double Get_Bonuses(Item each)
        {
            return 0;
        }
        public virtual double Get_Discount(Item each)
        {
            return 0;
        }
        public Goods(String title, IStrategy strategy)
        {
            _title = title;
        }
        public int getPriceCode()
        {
            return _priceCode;
        }
        public void setPriceCode(int arg)
        {
            _priceCode = arg;
        }
        public String getTitle()
        {
            return _title;
        }
    }
}