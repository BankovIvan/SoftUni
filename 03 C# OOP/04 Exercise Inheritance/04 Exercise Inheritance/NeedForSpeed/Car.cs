namespace NeedForSpeed
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Car : Vehicle
    {
        public new readonly double DefaultFuelConsumption = 3;
        public override double FuelConsumption => this.DefaultFuelConsumption;

        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }
    }
}
