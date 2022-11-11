namespace Vehicles.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Truck : Vehicle
    {
        private const double SUMMER_CONSUMPTION_MODIFIER = 1.6;
        private const double TANK_HOLE_MODIFIER = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption) : 
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
