namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WildFarm.Models.Foods;

    public class Tiger : Feline
    {
        private const double FOOD_MULTIPLIER = 1.0;

        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFood =>
            new HashSet<Type> { typeof(Meat) };

        protected override double WeightMultiplier { get => FOOD_MULTIPLIER; }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
