namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WildFarm.Models.Foods;

    public class Mouse : Mammal
    {
        private const double FOOD_MULTIPLIER = 0.1;

        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFood =>
            new HashSet<Type> { typeof(Fruit), typeof(Vegetable) };

        protected override double WeightMultiplier { get => FOOD_MULTIPLIER; }

        public override string ProduceSound()
        {
            return "Squeak";
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
