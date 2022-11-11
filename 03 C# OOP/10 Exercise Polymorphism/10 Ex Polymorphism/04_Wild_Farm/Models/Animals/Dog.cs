namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WildFarm.Models.Foods;

    public class Dog : Mammal
    {
        private const double FOOD_MULTIPLIER = 0.4;

        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFood =>
            new HashSet<Type> { typeof(Meat) };

        protected override double WeightMultiplier { get => FOOD_MULTIPLIER; }

        public override string ProduceSound()
        {
            return "Woof";
        }

        public override string ToString()
        {
            return String.Format(
                "{0} [{1}, {2}, {3}, {4}]",
                this.GetType().Name,
                this.Name,
                this.Weight,
                this.LivingRegion,
                this.FoodEaten);
        }
    }
}
