using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication27
{
    public abstract class AbstractContentFile
    {
        protected abstract string GetCustomer();
        protected abstract int GetGoodsCount(Item each);
        protected abstract int GetItemsCount(List<Item> _items);
    }
}
