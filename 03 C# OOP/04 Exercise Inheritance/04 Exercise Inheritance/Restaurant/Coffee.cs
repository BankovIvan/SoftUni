namespace Restaurant
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Coffee : HotBeverage
    {
        private const double DEFAULT_COFFEEMILLILITERS = 50;
        private const decimal DEFAULT_COFFEEPRICE = 3.50M;

        //private double coffeeMilliliters;
        //private decimal coffeePrice;
        private double caffeine;

        //public double CoffeeMilliliters { get { return coffeeMilliliters; } set { coffeeMilliliters = value; } }
        //public decimal CoffeePrice { get { return coffeePrice; } set { coffeePrice = value; } }
        public double Caffeine { get { return caffeine; } set { caffeine = value; } }

        public Coffee(string name, decimal price, double milliliters) : base(name, price, milliliters)
        {
            //this.CoffeeMilliliters = DEFAULT_COFFEEMILLILITERS;
            //this.CoffeePrice = DEFAULT_COFFEEPRICE;
            this.Caffeine = default(double);
        }

        public Coffee(string name, decimal price, double milliliters, double caffeine) : base(name, price, milliliters)
        {
            //this.CoffeeMilliliters = DEFAULT_COFFEEMILLILITERS;
            //this.CoffeePrice = DEFAULT_COFFEEPRICE;
            this.Caffeine = caffeine;
        }

        public Coffee(string name, double caffeine) : base(name, DEFAULT_COFFEEPRICE, DEFAULT_COFFEEMILLILITERS)
        {
            //this.CoffeeMilliliters = DEFAULT_COFFEEMILLILITERS;
            //this.CoffeePrice = DEFAULT_COFFEEPRICE;
            this.Caffeine = caffeine;
        }

    }
}
