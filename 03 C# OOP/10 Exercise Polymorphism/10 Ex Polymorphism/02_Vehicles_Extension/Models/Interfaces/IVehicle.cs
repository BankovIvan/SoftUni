namespace Vehicles.Models.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumption { get; }
        double TankCapacity { get; }

        string Drive(double distance);
        string DriveEmpty(double distance);
        string Refuel(double liters);

    }
}
