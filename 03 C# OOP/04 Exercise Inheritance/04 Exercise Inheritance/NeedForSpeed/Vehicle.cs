namespace NeedForSpeed
{
    using System;
    using System.Collections.Generic;
    using System.Reflection.Metadata.Ecma335;
    using System.Text;

    public class Vehicle
    {
        private int horsePower;
        private double fuel;

        public int HorsePower { get { return horsePower; } set { horsePower = value; } }
        public double Fuel { get { return fuel; } set { fuel = value; } }

        public readonly double DefaultFuelConsumption = 1.25;
        public virtual double FuelConsumption { get => this.DefaultFuelConsumption; }

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        public virtual void Drive(double kilometers)
        {
            double fuelLeft = this.Fuel - this.FuelConsumption * kilometers;
            if(this.Fuel >= 0)
            {
                this.Fuel = fuelLeft;
            }
            
        }
    }
}
