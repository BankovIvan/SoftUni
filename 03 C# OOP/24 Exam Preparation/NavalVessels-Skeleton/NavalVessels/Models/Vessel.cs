namespace NavalVessels.Models
{
    using NavalVessels.Models.Contracts;
    using NavalVessels.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Vessel : IVessel
    {
        private readonly double DEFAULT_ARMOUR;

        private string name;
        private ICaptain captain;
        private double armorThickness;
        private double mainWeaponCaliber;
        private double speed;
        private ICollection<string> targets;

        public string Name
        {
            get { return this.name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                }
                this.name = value; 
            }
        }

        public ICaptain Captain 
        { 
            get { return this.captain; }
            set 
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
                }
                this.captain = value; 
            }
        }

        public double ArmorThickness 
        {
            get { return this.armorThickness; }
            set { this.armorThickness = value; } 
        }

        public double MainWeaponCaliber
        {
            get { return this.mainWeaponCaliber; }
            protected set { this.mainWeaponCaliber = value; }
        }

        public double Speed
        {
            get { return this.speed; }
            protected set { this.speed = value; }
        }

        public ICollection<string> Targets
        {
            get { return this.targets; }
            private set { this.targets = value; }
        }

        private Vessel()
        {
            this.captain = null;
            this.Targets = new List<string>();
        }

        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness) : this()
        {
            this.Name = name;
            this.mainWeaponCaliber = mainWeaponCaliber;
            this.speed = speed;
            this.ArmorThickness = armorThickness;
            this.DEFAULT_ARMOUR = armorThickness;
        }

        public void Attack(IVessel target)
        {
            if(target == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }

            target.ArmorThickness -= this.MainWeaponCaliber;
            if (target.ArmorThickness < 0.0)
            {
                target.ArmorThickness = 0.0;
            }

            this.Targets.Add(target.Name);

            ////////////////////////////////////////////////////
            ///
            /// this.Captain.IncreaseCombatExperience();
            /// target.Captain.IncreaseCombatExperience();

        }

        public virtual void RepairVessel()
        {
            if(this.ArmorThickness < this.DEFAULT_ARMOUR)
            {
                this.ArmorThickness = this.DEFAULT_ARMOUR;
            }
        }

        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();

            ret.AppendLine(String.Format("- {0}", this.Name));
            ret.AppendLine(String.Format(" *Type: {0}", this.GetType().Name));
            ret.AppendLine(String.Format(" *Armor thickness: {0}", this.ArmorThickness));
            ret.AppendLine(String.Format(" *Main weapon caliber: {0}", this.MainWeaponCaliber));
            ret.AppendLine(String.Format(" *Speed: {0} knots", this.Speed));

            string targetsListed = "None";
            if(this.Targets.Count > 0)
            {
                targetsListed = String.Join(", ", this.Targets);
            }
            ret.AppendLine(String.Format(" *Targets: {0}", targetsListed));

            return ret.ToString().Trim();
        }

    }
}
