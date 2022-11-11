namespace Raiding.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Warrior : BaseHero
    {
        public Warrior(string name) : base(name, 100)
        {
        }

        public override string CastAbility()
        {
            StringBuilder ret = new StringBuilder();

            ret.AppendLine(String.Format("{0} - {1} hit for {2} damage", this.GetType().Name, this.Name, this.Power));

            return ret.ToString().Trim();
        }
    }
}
