using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private const int MIN_CAPACITY = 0;
        private const int SMALL_CAPACITY = 2;
        private const int LARGE_CAPACITY = 4;

        private Smartphone phone100;
        private Smartphone phone200;
        private Smartphone phone300;

        private Shop shop;

        [SetUp]
        public void Setup()
        {
            phone100 = new Smartphone("Nokia", 100);
            phone200 = new Smartphone("Siemens", 200);
            phone300 = new Smartphone("Ericksson", 300);
            shop = new Shop(SMALL_CAPACITY);
        }

        [Test]
        public void Test_01_SmartphoneShop_Constructor_Valid()
        {
            shop = new Shop(MIN_CAPACITY);
            Assert.AreEqual(shop.Capacity, MIN_CAPACITY);
            Assert.AreEqual(shop.Count, 0);

            shop = new Shop(SMALL_CAPACITY);
            Assert.AreEqual(shop.Capacity, SMALL_CAPACITY);
            Assert.AreEqual(shop.Count, 0);

            shop = new Shop(LARGE_CAPACITY);
            Assert.AreEqual(shop.Capacity, LARGE_CAPACITY);
            Assert.AreEqual(shop.Count, 0);

        }

        [Test]
        public void Test_02_SmartphoneShop_Constructor_Invalid()
        {
            Assert.Throws<ArgumentException>(() => shop = new Shop(MIN_CAPACITY - 1));

        }

        [Test]
        public void Test_03_SmartphoneShop_Count_Valid()
        {
            shop.Add(phone100);
            Assert.AreEqual(shop.Count, 1);

            shop.Add(phone200);
            Assert.AreEqual(shop.Count, shop.Capacity);

            shop.Remove(phone100.ModelName);
            Assert.AreEqual(shop.Count, 1);

            shop.Remove(phone200.ModelName);
            Assert.AreEqual(shop.Count, 0);

        }

        [Test]
        public void Test_04_SmartphoneShop_Count_Invalid()
        {
            // Already tested...

        }

        [Test]
        public void Test_05_SmartphoneShop_Add_Valid()
        {
            shop.Add(phone100);
            shop.Add(phone200);

            shop.TestPhone(phone100.ModelName, phone100.CurrentBateryCharge);
            shop.TestPhone(phone200.ModelName, phone200.CurrentBateryCharge);

            Assert.AreEqual(phone100.CurrentBateryCharge, 0);
            Assert.AreEqual(phone200.CurrentBateryCharge, 0);
        }

        [Test]
        public void Test_06_SmartphoneShop_Add_Invalid()
        {
            shop.Add(phone100);

            Assert.Throws<InvalidOperationException>(() => shop.Add(phone100));

            shop.Add(phone200);

            Assert.Throws<InvalidOperationException>(() => shop.Add(phone300));

        }

        [Test]
        public void Test_07_SmartphoneShop_Remove_Valid()
        {
            shop.Add(phone100);
            shop.Add(phone200);

            shop.Remove(phone200.ModelName);
            Assert.AreEqual(shop.Count, 1);

            shop.TestPhone(phone100.ModelName, phone100.CurrentBateryCharge);
            Assert.AreEqual(phone100.CurrentBateryCharge, 0);

            shop.Add(phone200);
            shop.Remove(phone100.ModelName);

            shop.TestPhone(phone200.ModelName, phone200.CurrentBateryCharge);
            Assert.AreEqual(phone200.CurrentBateryCharge, 0);

            shop.Remove(phone200.ModelName);
            Assert.AreEqual(shop.Count, 0);

        }

        [Test]
        public void Test_08_SmartphoneShop_Remove_Invalid()
        {
            shop.Add(phone100);

            Assert.Throws<InvalidOperationException>(() => shop.Remove(phone200.ModelName));

            shop.Remove(phone100.ModelName);

            Assert.Throws<InvalidOperationException>(() => shop.Remove(phone100.ModelName));

        }

        [Test]
        public void Test_09_SmartphoneShop_TestPhone_Valid()
        {
            shop.Add(phone100);
            shop.Add(phone200);

            shop.TestPhone(phone100.ModelName, 0);
            Assert.AreEqual(phone100.CurrentBateryCharge, phone100.MaximumBatteryCharge);

            shop.TestPhone(phone200.ModelName, 0);
            Assert.AreEqual(phone200.CurrentBateryCharge, phone200.MaximumBatteryCharge);

            shop.TestPhone(phone100.ModelName, 1);
            Assert.AreEqual(phone100.CurrentBateryCharge, phone100.MaximumBatteryCharge - 1);

            shop.TestPhone(phone200.ModelName, 1);
            Assert.AreEqual(phone200.CurrentBateryCharge, phone200.MaximumBatteryCharge - 1);

            shop.TestPhone(phone100.ModelName, phone100.CurrentBateryCharge);
            Assert.AreEqual(phone100.CurrentBateryCharge, 0);

            shop.TestPhone(phone200.ModelName, phone200.CurrentBateryCharge);
            Assert.AreEqual(phone200.CurrentBateryCharge, 0);

            shop.TestPhone(phone100.ModelName, 0);
            Assert.AreEqual(phone100.CurrentBateryCharge, 0);

            shop.TestPhone(phone200.ModelName, 0);
            Assert.AreEqual(phone200.CurrentBateryCharge, 0);

        }

        [Test]
        public void Test_10_SmartphoneShop_TestPhone_Invalid()
        {
            shop.Add(phone100);
            shop.Add(phone200);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone(phone300.ModelName, 0));
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone(phone100.ModelName, phone100.CurrentBateryCharge + 1));
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone(phone200.ModelName, phone200.CurrentBateryCharge + 1));
        }

        [Test]
        public void Test_11_SmartphoneShop_ChargePhone_Valid()
        {
            shop.Add(phone100);
            shop.Add(phone200);

            shop.TestPhone(phone100.ModelName, phone100.CurrentBateryCharge);
            shop.TestPhone(phone200.ModelName, phone200.CurrentBateryCharge);

            shop.ChargePhone(phone100.ModelName);
            Assert.AreEqual(phone100.CurrentBateryCharge, phone100.MaximumBatteryCharge);

            shop.ChargePhone(phone200.ModelName);
            Assert.AreEqual(phone200.CurrentBateryCharge, phone200.MaximumBatteryCharge);

            shop.TestPhone(phone100.ModelName, 1);
            shop.TestPhone(phone200.ModelName, 1);

            shop.ChargePhone(phone100.ModelName);
            Assert.AreEqual(phone100.CurrentBateryCharge, phone100.MaximumBatteryCharge);

            shop.ChargePhone(phone200.ModelName);
            Assert.AreEqual(phone200.CurrentBateryCharge, phone200.MaximumBatteryCharge);

            shop.ChargePhone(phone100.ModelName);
            Assert.AreEqual(phone100.CurrentBateryCharge, phone100.MaximumBatteryCharge);

            shop.ChargePhone(phone200.ModelName);
            Assert.AreEqual(phone200.CurrentBateryCharge, phone200.MaximumBatteryCharge);
        }

        [Test]
        public void Test_12_SmartphoneShop_ChargePhone_Invalid()
        {
            shop.Add(phone100);
            shop.Add(phone200);

            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone(phone300.ModelName));
        }

    }
}