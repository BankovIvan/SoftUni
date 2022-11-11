namespace Vehicles.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Vehicles.Models.Interfaces;

    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;

        public double FuelQuantity { get => this.fuelQuantity; private set => this.fuelQuantity = value; }
        public double FuelConsumption { get => this.fuelConsumption; private set => this.fuelConsumption = value; }

        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public virtual string Drive(double distance)
        {
            StringBuilder ret = new StringBuilder();
            double fuelSpent = distance * this.FuelConsumption;

            if(this.FuelQuantity >= fuelSpent)
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

        public virtual string Refuel(double liters)
        {
            StringBuilder ret = new StringBuilder();
            
            this.FuelQuantity += liters;
            ret.AppendLine(string.Format("{0} refueled {1} l", this.GetType().Name, liters));

            return ret.ToString().Trim();
        }

        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();

            //ret.AppendLine(string.Format("{0}: {1}", this.GetType().Name, Math.Round(this.FuelQuantity, 2, MidpointRounding.AwayFromZero)));
            ret.AppendLine(string.Format("{0}: {1:F2}", this.GetType().Name, this.FuelQuantity));

            return ret.ToString().Trim();
        }

    }
}
