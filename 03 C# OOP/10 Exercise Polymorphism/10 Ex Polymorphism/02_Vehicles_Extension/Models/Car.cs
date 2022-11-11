namespace Vehicles.Models
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class Car : Vehicle
    {
        private const double SUMMER_CONSUMPTION_MODIFIER = 0.9;
        //private const double TANK_HOLE_MODIFIER = 1.0;

        //public override double FuelConsumption {
        //    get => base.FuelConsumption + SUMMER_CONSUMPTION_MODIFIER;
        //}

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) :
            base(fuelQuantity, fuelConsumption + SUMMER_CONSUMPTION_MODIFIER, tankCapacity)
        {
        }

        public override string Drive(double distance)
        {
            //return base.Drive(distance + distance * SUMMER_CONSUMPTION_MODIFIER);
            return base.Drive(distance);
        }

        public override string Refuel(double liters)
        {
            return base.Refuel(liters);
        }

    }
}
