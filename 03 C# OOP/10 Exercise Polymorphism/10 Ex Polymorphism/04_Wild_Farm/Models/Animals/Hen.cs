namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WildFarm.Models.Foods;

    public class Hen : Bird
    {
        private const double FOOD_MULTIPLIER = 0.35;

        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFood =>
            new HashSet<Type> { typeof(Fruit), typeof(Meat) , typeof(Seeds), typeof(Vegetable) };

        protected override double WeightMultiplier { get => FOOD_MULTIPLIER; }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
