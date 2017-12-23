using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication27
{
    public class BillFactory
    {
        public Goods Create(string id, string name)
        {
            if (id == "Sale")
            {
                return new Sale(null, name);
            }
            if (id == "Regular")
            {
                return new Regular(null, name);
            }
            if (id == "Special")
            {
                return new Special(null, name);
            }
            return null;
        }
    }
}
