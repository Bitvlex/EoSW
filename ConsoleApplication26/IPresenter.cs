using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication27
{
    public interface IPresenter
    {
        string GetHeader(Customer _customer);
        string GetFooter(double amount, double bonuses);
        string Showing_result(double thisAmount, double discount, double bonus, Item each);
    }
}
