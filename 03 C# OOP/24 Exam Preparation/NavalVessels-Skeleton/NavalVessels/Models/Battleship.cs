namespace NavalVessels.Models
{
    using NavalVessels.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Battleship : Vessel, IBattleship
    {
        private const double DEFAULT_ARMOUR_CONST = 300.0;
        private const double WEAPON_INCREASE = 40.0;
        private const double SPEED_DECREASE = 5.0;

        private readonly double DEFAULT_CALIBER;
        private readonly double DEFAULT_SPEED;

        private bool sonarMode;

        public bool SonarMode
        {
            get { return sonarMode; }
            private set { sonarMode = value; }
        }

        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, DEFAULT_ARMOUR_CONST)
        {
            this.SonarMode = false;
            this.DEFAULT_CALIBER = mainWeaponCaliber;
            this.DEFAULT_SPEED = speed;
        }

        /*
        public Battleship(string name, double mainWeaponCaliber, double speed, double armorThickness)
            : base(name, mainWeaponCaliber, speed, armorThickness)
        {
            this.SonarMode = false;
        }
        */

        public void ToggleSonarMode()
        {
            this.SonarMode = !this.SonarMode;
            if(this.SonarMode == true)
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
            ret.AppendLine(String.Format(" *Sonar mode: {0}", this.SonarMode ? "ON" : "OFF"));

            return ret.ToString().Trim();
        }

    }
}
