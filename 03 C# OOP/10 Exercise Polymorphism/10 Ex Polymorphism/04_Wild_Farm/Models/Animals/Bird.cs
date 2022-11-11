namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text;
    using WildFarm.Models.Interfaces;

    public abstract class Bird : Animal, IBird
    {
        private double wingSize;

        protected Bird(string name, double weight, double wingSize) : base(name, weight)
        {
            this.WingSize = wingSize;   
        }

        public double WingSize { get => this.wingSize; private set => this.wingSize = value; }


        public override string ToString()
        {
            return String.Format(
                "{0} [{1}, {2}, {3}, {4}]", 
                this.GetType().Name, 
                this.Name, 
                this.WingSize, 
                this.Weight, 
                this.FoodEaten);
        }

    }
}
