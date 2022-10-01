namespace CarManufacturer
{
    using System;

    class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;

        public string Make { get { return make; } set { make = value; } }
        public string Model { get { return model; } set { model = value; } }
        public int Year { get { return year; } set { year = value; } }
        public double FuelQuantity { get { return fuelQuantity; } set { fuelQuantity = value; } }  
        public double FuelConsumption { get { return fuelConsumption; } set { fuelConsumption = value; } }

        public void Drive(double distance)
        {
            double mileage = distance * this.fuelConsumption;
            if(mileage < this.fuelQuantity)
            {
                this.fuelQuantity -= mileage;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            string ret = "Make: " + this.Make + "\n";
            ret += "Model: " + this.Model + "\n";
            ret += "Year: " + this.Year.ToString() + "\n";
            ret += "Fuel: " + string.Format("{0:F2}", this.fuelQuantity) + "\n";

            return ret;
        }

    }

    public class StartUp
    {
        static void Main(string[] args)
        {

            Car car = new Car();

            car.Make = "VW";
            car.Model = "MK3";
            car.Year = 1992;
            car.FuelQuantity = 200;
            car.FuelConsumption = 200;
            car.Drive(2000);
            Console.WriteLine(car.WhoAmI());

        }
    }
}