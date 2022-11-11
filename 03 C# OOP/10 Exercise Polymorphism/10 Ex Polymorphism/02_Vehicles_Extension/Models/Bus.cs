namespace Vehicles.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Bus : Vehicle
    {
        private const double SUMMER_CONSUMPTION_MODIFIER = 1.4;
        //private const double TANK_HOLE_MODIFIER = 1.0;
        private double emptyFuelConsumption;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) :
            base(fuelQuantity, fuelConsumption + SUMMER_CONSUMPTION_MODIFIER, tankCapacity)
        {
            this.emptyFuelConsumption = fuelConsumption;
        }

        public override string Drive(double distance)
        {
            return base.Drive(distance);

        }

        public override string DriveEmpty(double distance)
        {
            StringBuilder ret = new StringBuilder();
            double fuelSpent = distance * this.emptyFuelConsumption;

            if (this.FuelQuantity >= fuelSpent)
            {
                this.FuelQuantity -= fuelSpent;
                ret.AppendLine(String.Format("{0} travelled {1} km", this.GetType().Name, distance));
            }
            else
            {
                ret.AppendLine(string.Format("{0} needs refueling", this.GetType().Name));
            }

            return ret.ToString().Trim();
        }

        public override string Refuel(double liters)
        {
            return base.Refuel(liters);
        }



    }
}
