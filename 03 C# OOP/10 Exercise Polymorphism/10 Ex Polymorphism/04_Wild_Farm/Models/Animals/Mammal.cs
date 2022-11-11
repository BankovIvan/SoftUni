namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WildFarm.Models.Interfaces;

    public abstract class Mammal : Animal, IMammal
    {
        private string livingRegion;

        protected Mammal(string name, double weight, string livingRegion) : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get => this.livingRegion; private set => this.livingRegion = value; }
    }
}
