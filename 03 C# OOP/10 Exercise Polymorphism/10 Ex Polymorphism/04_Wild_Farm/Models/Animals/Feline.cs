namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WildFarm.Models.Interfaces;

    public abstract class Feline : Mammal, IFeline
    {
        private string breed;

        public string Breed { get => this.breed; set => this.breed = value; }

        protected Feline(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public override string ToString()
        {
            return String.Format(
                "{0} [{1}, {2}, {3}, {4}, {5}]",
                this.GetType().Name,
                this.Name,
                this.Breed,
                this.Weight,
                this.LivingRegion,
                this.FoodEaten);
        }

    }
}
