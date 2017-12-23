using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication27
{
    public interface IStrategy
    {
        double Algorithm(Item each);
    }
}
