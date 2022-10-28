namespace Restaurant
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Fish : MainDish
    {
        private const double DEFAULT_GRAMS = 22;

        public Fish(string name, decimal price, double grams) : base(name, price, grams)
        {
        }

        public Fish(string name, decimal price) : base(name, price, DEFAULT_GRAMS)
        {
        }

    }
}
