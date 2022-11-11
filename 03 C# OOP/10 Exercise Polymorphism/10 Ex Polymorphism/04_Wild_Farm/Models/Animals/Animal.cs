namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WildFarm.Exceptions;
    using WildFarm.Models.Interfaces;

    public abstract class Animal : IAnimal
    {
        private string name;
        private double weight;
        private int foodEaten;

        protected abstract double WeightMultiplier { get; }
        public abstract IReadOnlyCollection<Type> PreferredFood { get; }

        public string Name { get => this.name; private set => this.name = value; }
        public double Weight { get => this.weight; private set => this.weight = value; }
        public int FoodEaten { get => this.foodEaten; private set => this.foodEaten = value; }

        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }

        public void Eat(IFood food)
        {
            if(!this.PreferredFood.Any(t => food.GetType() == t))
            {
                throw new FoodNotEatenException(
                    string.Format(ExceptionMessages.FOOD_NOT_EATEN, this.GetType().Name, food.GetType().Name));
            }

            this.Weight += food.Quantity * this.WeightMultiplier;
            this.FoodEaten += food.Quantity;
        }

        public abstract string ProduceSound();

    }
}
