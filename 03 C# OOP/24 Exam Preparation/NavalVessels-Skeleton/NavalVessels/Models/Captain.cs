namespace NavalVessels.Models
{
    using NavalVessels.Models.Contracts;
    using NavalVessels.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Captain : ICaptain
    {
        private const int DEFAULT_EXPERIENCE = 0;
        private const int INCREASE_EXPERIENCE = 10;

        private string fullName;
        private int combatExperience;
        private ICollection<IVessel> vessels;

        public string FullName 
        {
            get { return this.fullName; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
                }
                this.fullName = value; 
            }
        }

        public int CombatExperience
        {
            get { return this.combatExperience; }
            private set 
            {
                if(value == (this.combatExperience + INCREASE_EXPERIENCE))
                {
                    this.combatExperience = value;
                }
            }
        }

        public ICollection<IVessel> Vessels
        {
            get { return this.vessels; }
            private set { this.vessels = value; }
        }

        private Captain()
        {
            this.Vessels = new List<IVessel>();
        }

        public Captain(string fullName) : this()
        {
            this.FullName = fullName;
            CombatExperience = DEFAULT_EXPERIENCE;
        }

        public void AddVessel(IVessel vessel)
        {
            if(vessel == null)
            {
                throw new ArgumentNullException(ExceptionMessages.InvalidVesselForCaptain);
            }

            this.Vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            this.CombatExperience += INCREASE_EXPERIENCE;
        }

        public string Report()
        {
            StringBuilder ret = new StringBuilder();

            ret.AppendLine(
                String.Format(
                    "{0} has {1} combat experience and commands {2} vessels.", 
                    this.FullName,
                    this.CombatExperience,
                    this.Vessels.Count));
            
            foreach(var v in this.Vessels)
            {
                ret.AppendLine(v.ToString());
            }

            return ret.ToString().Trim();
        }
    }
}
