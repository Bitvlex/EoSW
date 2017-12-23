using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication27;
using NUnit.Framework;

namespace TestLibrary
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void BaseTest()
        {
            BillFactory factory = new BillFactory();
            Goods fanta = factory.Create("Regular", "Fanta");
            Goods snikers = factory.Create("Sale", "snikers");
            int price_for_fanta = 45;
            int price_for_snikers = 33;
            Item i1 = new Item(fanta, 2, price_for_fanta);
            Item i2 = new Item(snikers, 3, price_for_snikers);
            Customer Denis = new Customer("Vadim&Volodya", 10);
            IPresenter p = new TXTPresenter();
            BillGenerator b1 = new BillGenerator(Denis, p);
            b1.addGoods(i1);
            b1.addGoods(i2);
            string bill = b1.GenerateBill();
            string actual = bill;
            string exepted = b1.GenerateBill();
            Assert.AreEqual(exepted, actual);
        }
        [Test]
        public void BaseTest_2()
        {
            BillFactory factory = new BillFactory();
            Goods cola = factory.Create("Special", "Cola");
            Goods pepsi = factory.Create("Sale", "Pepsi");
            Item i1 = new Item(cola, 6, 65);
            Item i2 = new Item(pepsi, 3, 50);
            IPresenter p = new TXTPresenter();
            Customer x = new Customer("Vadim&Volodya", 10);
            BillGenerator b1 = new BillGenerator(x, p);
            b1.addGoods(i1);
            b1.addGoods(i2);
            string bill = b1.GenerateBill();
            string actual = bill;
            string exepted = b1.GenerateBill();
            Assert.AreEqual(exepted, actual);
        }
        [Test]
        public void BaseTest_3()
        {
            BillFactory factory = new BillFactory();
            Goods beer = factory.Create("Sale", "Beer");
            Goods chips = factory.Create("Special", "Chips");
            Goods nuts = factory.Create("Sale", "Nuts");
            Item i1 = new Item(beer, 2, 67);
            Item i2 = new Item(chips, 4, 45);
            Item i3 = new Item(nuts, 2, 27);
            IPresenter p = new TXTPresenter();
            Customer x = new Customer("Vadim&Volodya", 15);
            BillGenerator b1 = new BillGenerator(x, p);
            b1.addGoods(i1);
            b1.addGoods(i2);
            b1.addGoods(i3);
            string bill = b1.GenerateBill();
            double actual = b1.f;
            double exepted = 351.19999999999999;
            Assert.AreEqual(exepted, actual);
        }
        [Test]
        public void Bonus_Test()
        {
            BillFactory factory = new BillFactory();
            Goods cola = factory.Create("Special", "Cola");
            Goods pepsi = factory.Create("Sale", "Pepsi");
            Item i1 = new Item(cola, 6, 65);
            Item i2 = new Item(pepsi, 3, 50);
            Customer x = new Customer("Vadim&Volodya", 10);
            IPresenter p = new TXTPresenter();
            BillGenerator b1 = new BillGenerator(x, p);
            b1.addGoods(i1);
            b1.addGoods(i2);
            string bill = b1.GenerateBill();
            double actual = b1.bonus;
            double exepted = 10;
            Assert.AreEqual(exepted, actual);
        }
        [Test]
        public void Discount_Test()
        {
            BillFactory factory = new BillFactory();
            Goods cola = factory.Create("Special", "Cola");
            Item i1 = new Item(cola, 6, 65);
            Customer x = new Customer("Vadim&Volodya", 10);
            IPresenter p = new TXTPresenter();
            BillGenerator b1 = new BillGenerator(x, p);
            b1.addGoods(i1);
            string bill = b1.GenerateBill();
            double actual = b1.discount_1;
            double exepted = 13.9;
            Assert.AreEqual(exepted, actual);
        }
        [Test]
        public void HTML_Presenter_test()
        {
            BillFactory factory = new BillFactory();
            Goods cola = factory.Create("Regular", "Cola");
            Goods pepsi = factory.Create("Sale", "Pepsi");
            int price_for_fanta = 45;
            int price_for_snikers = 33;
            Item i1 = new Item(cola, 2, price_for_fanta);
            Item i2 = new Item(pepsi, 3, price_for_snikers);
            Customer Denis = new Customer("Vadim&Volodya", 10);
            IPresenter p = new HTMLPresenter();
            BillGenerator b1 = new BillGenerator(Denis, p);
            b1.addGoods(i1);
            b1.addGoods(i2);
            string bill = b1.GenerateBill();
            string actual = bill;
            string exepted = b1.GenerateBill();
            Assert.AreEqual(exepted, actual);
        }
        [Test]
        public void TXT_Presenter_test()
        {
            BillFactory factory = new BillFactory();
            Goods cola = factory.Create("Regular", "Cola");
            Goods pepsi = factory.Create("Sale", "Pepsi");
            int price_for_fanta = 45;
            int price_for_snikers = 33;
            Item i1 = new Item(cola, 2, price_for_fanta);
            Item i2 = new Item(pepsi, 3, price_for_snikers);
            Customer Denis = new Customer("Vadim&Volodya", 10);
            IPresenter p = new TXTPresenter();
            BillGenerator b1 = new BillGenerator(Denis, p);
            b1.addGoods(i1);
            b1.addGoods(i2);
            string bill = b1.GenerateBill();
            string actual = bill;
            string exepted = b1.GenerateBill();
            Assert.AreEqual(exepted, actual);
        }
    }
}