namespace _06_Speed_Racing
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double distanceTraveled;

        public string Model { get { return this.model; } set { this.model = value; } }
        public double FuelAmount { get { return this.fuelAmount; } set { this.fuelAmount = value; } }
        public double FuelConsumptionPerKilometer 
        { 
            get { return this.fuelConsumptionPerKilometer; } 
            set { this.fuelConsumptionPerKilometer = value; } 
        }
        public double DistanceTraveled { get { return this.distanceTraveled; } set { this.distanceTraveled = value; } }

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            DistanceTraveled = 0.0;
        }

        public void Drive(double amountOfKm)
        {
            double dMileage = amountOfKm * this.FuelConsumptionPerKilometer;
            if(this.FuelAmount >= dMileage)
            {
                this.FuelAmount -= dMileage;
                this.DistanceTraveled += amountOfKm;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Insufficient fuel for the drive");
                Console.ResetColor();
            }

        }

    }
}
