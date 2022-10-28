namespace NeedForSpeed
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text;

    public class RaceMotorcycle : Motorcycle
    {
        public new readonly double DefaultFuelConsumption = 8;
        public override double FuelConsumption => this.DefaultFuelConsumption;

        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }

    }
}
