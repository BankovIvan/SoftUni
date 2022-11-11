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
        private double tankCapacity;

        public double FuelQuantity {
            get { return this.fuelQuantity; } 
            protected set {
                if(value > this.TankCapacity)
                {
                    throw new ArithmeticException(String.Format("Cannot fit {0} fuel in the tank", value));
                }
                this.fuelQuantity = value;
            } 
        }
        public double FuelConsumption { get => this.fuelConsumption; set => this.fuelConsumption = value; }
        public double TankCapacity { get => this.tankCapacity; private set => this.tankCapacity = value; }

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            if (fuelQuantity > this.TankCapacity)
            {
                this.FuelQuantity = 0.0;
            }
            else
            {
                this.FuelQuantity = fuelQuantity;
            }
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

        public virtual string DriveEmpty(double distance)
        {
            return this.Drive(distance);
        }

        public virtual string Refuel(double liters)
        {
            StringBuilder ret = new StringBuilder();

            if(liters <= 0.0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            double totalFuel = this.FuelQuantity + liters;
            if(totalFuel > this.TankCapacity)
            {
                throw new ArithmeticException(String.Format("Cannot fit {0} fuel in the tank", liters));
            }
            
            this.FuelQuantity = totalFuel;

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
