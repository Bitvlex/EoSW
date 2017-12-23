using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace ConsoleApplication27
{
    public class BillFactory
    {
        public Goods Create(string id, string name)
        {
            string c = ConfigurationManager.AppSettings["Bonuses"];
            double k = Convert.ToDouble(c);
            string u = ConfigurationManager.AppSettings["Discount"];
            double h = Convert.ToDouble(u);
            string regular_app1 = ConfigurationManager.AppSettings["Regular"];
            int regular_app11 = Convert.ToInt32(regular_app1);
            string regular_app2 = ConfigurationManager.AppSettings["Special"];
            int regular_app22 = Convert.ToInt32(regular_app2);
            string regular_app3 = ConfigurationManager.AppSettings["Sale"];
            int regular_app33 = Convert.ToInt32(regular_app3);
            IStrategy strategy = null;
            if (id == "SAL")
            {
                strategy = new discountStrategy(regular_app33, h);
                return new Sale("Sale", name, strategy);
            }
            if (id == "REG")
            {
                strategy = new discountStrategy(regular_app11, h);
                return new Regular("Regular", name, strategy);
            }
            if (id == "SPO")
            {
                strategy = new bonusStrategy(regular_app22, k);
                return new Sale("Special", name, strategy);
            }
            return null;
        }
    }
}
