namespace Military.Models
{
    using Military.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Commando : SpecialisedSoldier, ICommando
    {
        private List<IMission> missions;

        public IReadOnlyCollection<IMission> Missions => this.missions.AsReadOnly();


        public Commando(long id, string firstName, string lastName, decimal salary, string corps) : 
            base(id, firstName, lastName, salary, corps)
        {
            this.missions = new List<IMission>();
        }

        public void AddMission(IMission m)
        {
            this.missions.Add(m);
        }

        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();

            ret.AppendLine(base.ToString());
            ret.AppendLine("Missions:");
            foreach (var v in this.Missions)
            {
                ret.Append("  ");
                ret.AppendLine(v.ToString());
            }

            return ret.ToString().Trim();
        }

    }
}
