namespace Military.Models
{
    using Military.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private List<IRepair> repairs;

        public IReadOnlyCollection<IRepair> Repairs => this.repairs.AsReadOnly();

        public void AddRepair(IRepair repair)
        {
            this.repairs.Add(repair);
        }

        public Engineer(long id, string firstName, string lastName, decimal salary, string corps) : 
            base(id, firstName, lastName, salary, corps)
        {
            this.repairs = new List<IRepair>();
        }

        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();

            ret.AppendLine(base.ToString());
            ret.AppendLine("Repairs:");
            foreach (var v in this.Repairs)
            {
                ret.Append("  ");
                ret.AppendLine(v.ToString());
            }

            return ret.ToString().Trim();
        }
    }
}
