namespace Military.Models
{
    using Military.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Mission : IMission
    {
        private static readonly HashSet<string> MISSION_STATES =
            new HashSet<string>(new string[] { "inProgress", "Finished" });

        private string codeName;
        private string state;

        public string CodeName { get => this.codeName; set => this.codeName = value; }
        public string State
        {
            get { return this.state; }
            set
            {
                if (!MISSION_STATES.Contains(value))
                {
                    throw new ArgumentException("Invalid mission state!");
                }
                this.state = value;
            }
        }

        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public void CompleteMission()
        {
            this.State = "Finished";
        }

        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();

            ret.AppendLine(String.Format("Code Name: {0} State: {1}", this.CodeName, this.State));

            return ret.ToString().Trim();
        }

    }
}
