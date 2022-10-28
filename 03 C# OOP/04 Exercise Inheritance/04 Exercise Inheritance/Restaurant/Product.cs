namespace Restaurant
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Product
    {
        private string name;
        private decimal price;

        public string Name { get { return name; } set { name = value; } }
        public decimal Price { get { return price; } set { price = value; } }

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
}
