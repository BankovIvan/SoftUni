namespace WildFarm.Models.Foods
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WildFarm.Models.Interfaces;

    public abstract class Food : IFood
    {
        private int quantity;

        public int Quantity { get => this.quantity; private set => this.quantity = value; }

        public Food(int quantity)
        {
            this.Quantity = quantity;
        }   
    }
}
