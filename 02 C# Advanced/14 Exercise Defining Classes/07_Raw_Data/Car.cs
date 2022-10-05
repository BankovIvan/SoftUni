namespace _07_Raw_Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Car
    {
        private string model;
        
        public EngineClass Engine { get; set; }
        public CargoClass Cargo { get; set; }
        public List<TireClass> Tires { get; set; }

        public string Model { get { return model; } set { model = value; } }

        public Car()
        {
            Tires = new List<TireClass>();
        }

        public Car(string model, 
                    int engineSpeed, 
                    int enginePower, 
                    int cargoWeight, 
                    string cargoType, 
                    double tire1Pressure,
                    int tire1Age,
                    double tire2Pressure,
                    int tire2Age, 
                    double tire3Pressure, 
                    int tire3Age, 
                    double tire4Pressure, 
                    int tire4Age) : this()
        {
            Model = model;
            Engine = new EngineClass(engineSpeed, enginePower);
            Cargo = new CargoClass(cargoType, cargoWeight);
            Tires.Add(new TireClass(tire1Age, tire1Pressure));
            Tires.Add(new TireClass(tire2Age, tire2Pressure));
            Tires.Add(new TireClass(tire3Age, tire3Pressure));
            Tires.Add(new TireClass(tire4Age, tire4Pressure));

        }
    }
}
