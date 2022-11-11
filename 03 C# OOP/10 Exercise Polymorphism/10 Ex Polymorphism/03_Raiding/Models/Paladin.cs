namespace Raiding.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Paladin : BaseHero
    {
        public Paladin(string name) : base(name, 100)
        {
        }

        public override string CastAbility()
        {
            StringBuilder ret = new StringBuilder();

            ret.AppendLine(String.Format("{0} - {1} healed for {2}", this.GetType().Name, this.Name, this.Power));

            return ret.ToString().Trim();
        }
    }
}
