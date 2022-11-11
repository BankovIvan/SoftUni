namespace Vehicles.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Car : Vehicle
    {
        private const double SUMMER_CONSUMPTION_MODIFIER = 0.9;
        private const double TANK_HOLE_MODIFIER = 1.0;

        public Car(double fuelQuantity, double fuelConsumption) :
            base(fuelQuantity, fuelConsumption + SUMMER_CONSUMPTION_MODIFIER)
        {
        }

        public override string Drive(double distance)
        {
            //return base.Drive(distance + distance * SUMMER_CONSUMPTION_MODIFIER);
            return base.Drive(distance);
        }

        public override string Refuel(double liters)
        {
            return base.Refuel(liters * TANK_HOLE_MODIFIER);
        }

    }
}
