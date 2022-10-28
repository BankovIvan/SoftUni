namespace NeedForSpeed
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SportCar : Car
    {
        public new readonly double DefaultFuelConsumption = 10;
        public override double FuelConsumption => this.DefaultFuelConsumption;

        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }
    }
}
