namespace Military.Models
{
    using Military.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private static readonly HashSet<string> CORPS_TYPES = 
            new HashSet<string>(new string[] { "Airforces", "Marines" });

        private string corps;

        public string Corps {
            get { return this.corps; } 
            set
            {
                if (!CORPS_TYPES.Contains(value))
                {
                    throw new ArgumentException("Invalid corps type!");
                }
                this.corps = value;
            } 
        }

        public SpecialisedSoldier(long id, string firstName, string lastName, decimal salary, string corps) : 
            base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();

            ret.AppendLine(base.ToString());
            ret.AppendLine(String.Format("Corps: {0}", this.Corps));

            return ret.ToString().Trim();
        }

    }
}
