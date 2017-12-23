using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ConsoleApplication27
{
    public class Program
    {
        static void Main(string[] args)
        {
            Goods cola = new Sale("Cola");
            Goods pepsi = new Regular("Pepsi");
            Item i1 = new Item(cola, 6, 65);
            Item i2 = new Item(pepsi, 3, 50);
            Customer x = new Customer("Denis", 10);
            IPresenter p = new TXTPresenter();
            BillGenerator b1 = new BillGenerator(x, p);
            b1.addGoods(i1);
            b1.addGoods(i2);
            string bill = b1.GenerateBill();
            Console.WriteLine(bill);
            Console.ReadLine();
        }
    }
}
