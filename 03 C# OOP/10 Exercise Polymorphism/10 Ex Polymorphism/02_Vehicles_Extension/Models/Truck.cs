namespace Vehicles.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Truck : Vehicle
    {
        private const double SUMMER_CONSUMPTION_MODIFIER = 1.6;
        private const double TANK_HOLE_MODIFIER = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : 
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
            StringBuilder ret = new StringBuilder();

            if (liters <= 0.0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            double totalFuel = this.FuelQuantity + liters * TANK_HOLE_MODIFIER;
            if (totalFuel > this.TankCapacity)
            {
                throw new ArithmeticException(String.Format("Cannot fit {0} fuel in the tank", liters));
            }

            this.FuelQuantity = totalFuel;

            ret.AppendLine(string.Format("{0} refueled {1} l", this.GetType().Name, liters));

            return ret.ToString().Trim();
        }
    }
}
