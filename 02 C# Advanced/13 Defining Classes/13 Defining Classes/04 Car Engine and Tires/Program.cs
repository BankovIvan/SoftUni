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
        private Engine engine;
        private Tire[] tires;

        public string Make { get { return make; } set { make = value; } }
        public string Model { get { return model; } set { model = value; } }
        public int Year { get { return year; } set { year = value; } }
        public double FuelQuantity { get { return fuelQuantity; } set { fuelQuantity = value; } }
        public double FuelConsumption { get { return fuelConsumption; } set { fuelConsumption = value; } }
        public Engine Engine { get { return engine; } set { engine = value; } } 
        public Tire[] Tires { get { return tires; } set { tires = value; } } 

        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;

        }

        public Car(string make, string model, int year) : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;

        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption) : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public Car(string make, 
                    string model, 
                    int year, 
                    double fuelQuantity, 
                    double fuelConsumption, 
                    Engine engine, 
                    Tire[] tires) : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }

        public void Drive(double distance)
        {
            double mileage = distance * this.fuelConsumption;
            if (mileage < this.fuelQuantity)
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

    public class Engine
    {
        private int horsePower;
        private double cubicCapacity;

        public int HorsePower { get { return horsePower; } set { horsePower = value; } }
        public double CubicCapacity { get { return cubicCapacity; } set { cubicCapacity = value; } }

        public Engine(int horsePower, double cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;

        }
    }

    public class Tire
    {
        private int year;
        private double pressure;

        public int Year { get { return year; } set { year = value; } }  
        public double Pressure { get { return pressure; } set { pressure = value; } }   

        public Tire(int year, double pressure) 
        { 
            this.Year = year; 
            this.Pressure = pressure; 
        }  

    }

    public class StartUp
    {
        static void Main(string[] args)
        {
            var tires = new Tire[4]
            {
                new Tire(1, 2.5),
                new Tire(1, 2.1),
                new Tire(2, 0.5),
                new Tire(2, 2.3)
            };

            var engine = new Engine(560, 6300);

            var car = new Car("Lamborgini", "Urus", 2010, 250, 9, engine, tires);

        }
    }
}