namespace NavalVessels.Models
{
    using NavalVessels.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Submarine : Vessel, ISubmarine
    {
        private const double DEFAULT_ARMOUR_CONST = 200.0;
        private const double WEAPON_INCREASE = 40.0;
        private const double SPEED_DECREASE = 4.0;

        private readonly double DEFAULT_CALIBER;
        private readonly double DEFAULT_SPEED;

        private bool submergeMode;

        public bool SubmergeMode
        {
            get { return submergeMode; }
            private set { submergeMode = value; }
        }

        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, DEFAULT_ARMOUR_CONST)
        {
            this.SubmergeMode = false;
            this.DEFAULT_CALIBER = mainWeaponCaliber;
            this.DEFAULT_SPEED = speed; 
        }

        /*
        public Submarine(string name, double mainWeaponCaliber, double speed, double armorThickness)
            : base(name, mainWeaponCaliber, speed, armorThickness)
        {
            this.SubmergeMode = false;
        }
        */

        public void ToggleSubmergeMode()
        {
            this.SubmergeMode = !this.SubmergeMode;
            if (this.SubmergeMode == true)
            {
                this.MainWeaponCaliber += WEAPON_INCREASE;
                this.Speed -= SPEED_DECREASE;
            }
            else
            {
                this.MainWeaponCaliber = this.DEFAULT_CALIBER;
                this.Speed = this.DEFAULT_SPEED;
            }
        }

        public override string ToString()
        {
            StringBuilder ret = new StringBuilder(base.ToString());

            ret.AppendLine();
            ret.AppendLine(String.Format(" *Submerge mode: {0}", this.SubmergeMode ? "ON" : "OFF"));

            return ret.ToString().Trim();
        }

    }
}
