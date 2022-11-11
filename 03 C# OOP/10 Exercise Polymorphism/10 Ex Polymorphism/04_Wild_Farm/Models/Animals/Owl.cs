namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WildFarm.Models.Foods;

    public class Owl : Bird
    {
        private const double FOOD_MULTIPLIER = 0.25;

        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFood =>
            new HashSet<Type> { typeof(Meat) };

        protected override double WeightMultiplier { get => FOOD_MULTIPLIER; }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
