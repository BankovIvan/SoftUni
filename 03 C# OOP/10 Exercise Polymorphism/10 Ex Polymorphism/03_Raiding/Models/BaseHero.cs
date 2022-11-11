namespace Raiding.Models
{
    using Raiding.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class BaseHero : IBaseHero
    {
        private string name;
        private int power;

        public string Name { get => this.name; private set => this.name = value; }
        public int Power { get => this.power; private set => this.power = value; }

        public BaseHero(string name, int power)
        {
            this.Name = name;
            this.Power = power;
        }

        public abstract string CastAbility();

    }
}
