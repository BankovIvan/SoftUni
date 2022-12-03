namespace NavalVessels.Core
{
    using NavalVessels.Core.Contracts;
    using NavalVessels.Models;
    using NavalVessels.Models.Contracts;
    using NavalVessels.Repositories;
    using NavalVessels.Repositories.Contracts;
    using NavalVessels.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Linq;

    public class Controller : IController
    {
        private IRepository<IVessel> vessels = new VesselRepository();
        private Dictionary<string, ICaptain> captains = new Dictionary<string, ICaptain>();

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            StringBuilder ret = new StringBuilder();

            if (!this.captains.ContainsKey(selectedCaptainName))
            {
                ret.AppendLine(String.Format(OutputMessages.CaptainNotFound, selectedCaptainName));
                return ret.ToString().Trim();
            }

            ICaptain captain = this.captains[selectedCaptainName];
            IVessel vessel = this.vessels.FindByName(selectedVesselName);

            if (vessel == null)
            {
                ret.AppendLine(String.Format(OutputMessages.VesselNotFound, selectedVesselName));
                return ret.ToString().Trim();
            }

            if (vessel.Captain != null)
            {
                ret.AppendLine(String.Format(OutputMessages.VesselOccupied, selectedVesselName));
                return ret.ToString().Trim();
            }

            vessel.Captain = captain;
            captain.AddVessel(vessel);

            ret.AppendLine(String.Format(OutputMessages.SuccessfullyAssignCaptain, captain.FullName, vessel.Name));

            return ret.ToString().Trim();
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            StringBuilder ret = new StringBuilder();

            IVessel attacker = this.vessels.FindByName(attackingVesselName);
            IVessel defender = this.vessels.FindByName(defendingVesselName);

            if(attacker == null)
            {
                ret.AppendLine(String.Format(OutputMessages.VesselNotFound, attackingVesselName));
                return ret.ToString().Trim();
            }

            if (defender == null)
            {
                ret.AppendLine(String.Format(OutputMessages.VesselNotFound, defendingVesselName));
                return ret.ToString().Trim();
            }

            if (attacker.ArmorThickness <= 0.0)
            {
                ret.AppendLine(String.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName));
                return ret.ToString().Trim();
            }

            if (defender.ArmorThickness <= 0.0)
            {
                ret.AppendLine(String.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName));
                return ret.ToString().Trim();
            }

            attacker.Attack(defender);
            attacker.Captain.IncreaseCombatExperience();
            defender.Captain.IncreaseCombatExperience();

            ret.AppendLine(
                String.Format(
                    OutputMessages.SuccessfullyAttackVessel,
                        defender.Name,
                        attacker.Name,
                        defender.ArmorThickness));

            return ret.ToString().Trim();
        }

        public string CaptainReport(string captainFullName)
        {
            StringBuilder ret = new StringBuilder();

            if (this.captains.ContainsKey(captainFullName))
            {
                ret.AppendLine(this.captains[captainFullName].Report());
            }

            return ret.ToString().Trim();
        }

        public string HireCaptain(string fullName)
        {
            StringBuilder ret = new StringBuilder();

            if (!this.captains.ContainsKey(fullName))
            {
                ICaptain captain = new Captain(fullName);
                this.captains.Add(fullName, captain);
                ret.AppendLine(
                    String.Format(
                        OutputMessages.SuccessfullyAddedCaptain, 
                        captain.FullName));
            }
            else
            {
                ret.AppendLine(String.Format(OutputMessages.CaptainIsAlreadyHired, fullName));
            }

            return ret.ToString().Trim();
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            StringBuilder ret = new StringBuilder();

            if (this.vessels.FindByName(name) != null)
            {
                ret.AppendLine(String.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name));
                return ret.ToString().Trim();
            }

            if (vesselType == "Battleship")
            {
                IVessel vessel = new Battleship(name, mainWeaponCaliber, speed);
                this.vessels.Add(vessel);
                ret.AppendLine(
                    String.Format(
                        OutputMessages.SuccessfullyCreateVessel,
                        vessel.GetType().Name, vessel.Name, vessel.MainWeaponCaliber, vessel.Speed));
            }
            else if (vesselType == "Submarine")
            {
                IVessel vessel = new Submarine(name, mainWeaponCaliber, speed);
                this.vessels.Add(vessel);
                ret.AppendLine(
                    String.Format(
                        OutputMessages.SuccessfullyCreateVessel,
                        vessel.GetType().Name, vessel.Name, vessel.MainWeaponCaliber, vessel.Speed));
            }
            else
            {
                ret.AppendLine(String.Format(OutputMessages.InvalidVesselType));
            }

            return ret.ToString().Trim();
        }

        public string ServiceVessel(string vesselName)
        {
            StringBuilder ret = new StringBuilder();

            IVessel vessel = this.vessels.FindByName(vesselName);

            if (vessel == null)
            {
                ret.AppendLine(String.Format(OutputMessages.VesselNotFound, vesselName));
                return ret.ToString().Trim();
            }

            vessel.RepairVessel();

            ret.AppendLine(String.Format(OutputMessages.SuccessfullyRepairVessel, vessel.Name));

            return ret.ToString().Trim();
        }

        public string ToggleSpecialMode(string vesselName)
        {
            StringBuilder ret = new StringBuilder();

            IVessel vessel = this.vessels.FindByName(vesselName);

            if (vessel == null)
            {
                ret.AppendLine(String.Format(OutputMessages.VesselNotFound, vesselName));
                return ret.ToString().Trim();
            }

            if (vessel.GetType().Name == "Battleship")
            {
                ((Battleship)vessel).ToggleSonarMode();
                ret.AppendLine(String.Format(OutputMessages.ToggleBattleshipSonarMode, vessel.Name));
            }
            else if (vessel.GetType().Name == "Submarine")
            {
                ((Submarine)vessel).ToggleSubmergeMode();
                ret.AppendLine(String.Format(OutputMessages.ToggleSubmarineSubmergeMode, vessel.Name));
            }
            else
            {
                // throw new NotImplementedException(String.Format("No Sonar Mode for Vessel {0}!", vesselName));
            }

            return ret.ToString().Trim();
        }

        public string VesselReport(string vesselName)
        {
            StringBuilder ret = new StringBuilder();
            IVessel vessel = this.vessels.FindByName(vesselName);

            if (vessel != null)
            {
                ret.AppendLine(vessel.ToString());
            }

            return ret.ToString().Trim();
        }
    }
}
