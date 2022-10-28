namespace Restaurant
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Cake : Dessert
    {
        private const double DEFAULT_GRAMS = 250;
        private const double DEFAULT_CALORIES = 1000;
        private const decimal DEFAULT_CAKEPRICE = 5M;

        //private double cakePrice;

        //public double CakePrice { get { return cakePrice; } set { cakePrice = value; } }

        public Cake(string name, decimal price, double grams, double calories) : base(name, price, grams, calories)
        {
            //this.CakePrice = DEFAULT_CAKEPRICE;
        }

        public Cake(string name, decimal price) : base(name, price, DEFAULT_GRAMS, DEFAULT_CALORIES)
        {
            //this.CakePrice = DEFAULT_CAKEPRICE;
        }

        public Cake(string name) : base(name, DEFAULT_CAKEPRICE, DEFAULT_GRAMS, DEFAULT_CALORIES)
        {
            //this.CakePrice = DEFAULT_CAKEPRICE;
        }

    }
}
