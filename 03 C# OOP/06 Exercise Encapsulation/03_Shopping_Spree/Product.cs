namespace _03_Shopping_Spree
{
    using System;
    
    public class Product
    {
        private readonly string name;
        private readonly decimal cost;

        public string Name { get => this.name; }
        public decimal Cost { get => this.cost; }

        public Product(string name, decimal cost){
            if(string.IsNullOrWhiteSpace(name)){
                throw new ArgumentException("Name cannot be empty");
            }
            if(cost < 0.0M){
                throw new ArgumentException("Money cannot be negative");
            }

            this.name = name;
            this.cost = cost;
        }

        public override string ToString()
        {
            return this.Name;
        }

    }
}