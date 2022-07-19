using System;
using System.Collections.Generic;
using System.Numerics;

namespace _M05_Shopping_Spree
{
    class Product
    {
        public string ProductName { get; set; }
        public int ProductCost { get; set; }

        public Product(string ProductName, string ProductCost)
        {
            this.ProductName = ProductName;
            this.ProductCost = int.Parse(ProductCost);
        }

        public Product(string ProductName, int ProductCost)
        {
            this.ProductName = ProductName;
            this.ProductCost = ProductCost;
        }

        public override string ToString()
        {
            return this.ProductName;
        }

    }

    class Person
    {
        public string PersonName { get; set; }
        public int PersonMoney { get; set; }

        public List<Product> PersonProducts { get; set; }

        public Person(string PersonName, string PersonMoney)
        {
            this.PersonName = PersonName;
            this.PersonMoney = int.Parse(PersonMoney);
            this.PersonProducts = new List<Product>();
        }

        public override string ToString()
        {
            if (this.PersonProducts.Count > 0)
            {
                return string.Format("{0} - {1}", this.PersonName, string.Join(", ", this.PersonProducts));
            }

            return string.Format("{0} - Nothing bought", this.PersonName);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> lstPersons = new List<Person>();
            List<Product> lstProducts = new List<Product>();
            string[] arrInput, arrItem;

            arrInput = Console.ReadLine().Split(';');
            foreach (string s in arrInput)
            {
                arrItem = s.Split('=');
                lstPersons.Add(new Person(arrItem[0], arrItem[1]));
            }

            arrInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in arrInput)
            {
                arrItem = s.Split('=');
                lstProducts.Add(new Product(arrItem[0], arrItem[1]));
            }

            while (true)
            {
                arrInput = Console.ReadLine().Split(' ');
                if (arrInput[0].ToUpper() == "END")
                {
                    break;
                }

                PurchaseProduct(lstPersons, lstProducts, arrInput[0], arrInput[1]);

            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            lstPersons.ForEach(x => Console.WriteLine(x));
            Console.ResetColor();

        }

        static void PurchaseProduct(List<Person> lstPersons, List<Product> lstProducts, string PersonName, string ProductName)
        {
            Person Byer = lstPersons.Find(x => x.PersonName == PersonName);
            Product Purchase = lstProducts.Find(x => x.ProductName == ProductName);
            int price = Byer.PersonMoney - Purchase.ProductCost;

            if (price >= 0)
            {
                Byer.PersonMoney = price;
                Byer.PersonProducts.Add(new Product(Purchase.ProductName, Purchase.ProductCost));
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("{0} bought {1}", Byer.PersonName, Purchase.ProductName);
                Console.ResetColor();

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("{0} can't afford {1}", Byer.PersonName, Purchase.ProductName);
                Console.ResetColor();
            }
        }

    }
}