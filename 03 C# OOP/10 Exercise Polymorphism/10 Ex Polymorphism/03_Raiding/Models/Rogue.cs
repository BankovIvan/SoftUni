namespace Raiding.Models
{
    using Raiding.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Rogue : BaseHero
    {
        public Rogue(string name) : base(name, 80)
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
