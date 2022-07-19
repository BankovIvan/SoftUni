using System;
using System.Collections.Generic;
using System.Numerics;

namespace _M04_Raw_Data
{
    class Program
    {
        class Engine
        {
            public int EngineSpeed { get; set; }
            public int EnginePower { get; set; }
        }

        class Cargo
        {
            public int CargoWeight { get; set; }
            public string CargoType { get; set; }
        }

        class Car
        {
            public string CarModel { get; set; }
            public Engine CarEngine { get; set; }
            public Cargo CarCargo { get; set; }

            public Car(string CarModel, string EngineSpeed, string EnginePower, string CargoWeight, string CargoType)
            {
                this.CarEngine = new Engine();
                this.CarCargo = new Cargo();

                this.CarModel = CarModel;
                this.CarEngine.EngineSpeed = int.Parse(EngineSpeed);
                this.CarEngine.EnginePower = int.Parse(EnginePower);
                this.CarCargo.CargoWeight = int.Parse(CargoWeight);
                this.CarCargo.CargoType = CargoType;
            }

        }

        static void Main(string[] args)
        {
            List<Car> lstCars = new List<Car>();
            string[] arrInput;
            int i, nRepeat;
            string sTypeToPrint;

            nRepeat = int.Parse(Console.ReadLine());

            for (i = 0; i < nRepeat; i++)
            {
                arrInput = Console.ReadLine().Split(' ');
                lstCars.Add(new Car(
                    arrInput[0],
                    arrInput[1],
                    arrInput[2],
                    arrInput[3],
                    arrInput[4]
                ));
            }

            sTypeToPrint = Console.ReadLine().ToLower();
            if (sTypeToPrint == "fragile")
            {
                lstCars.ForEach(x => {
                    if (x.CarCargo.CargoType == "fragile" && x.CarCargo.CargoWeight < 1000)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(x.CarModel);
                        Console.ResetColor();
                    }
                });
            }
            else if (sTypeToPrint == "flamable")
            {
                lstCars.ForEach(x => {
                    if (x.CarCargo.CargoType == "flamable" && x.CarEngine.EnginePower > 250)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(x.CarModel);
                        Console.ResetColor();
                    }
                });
            }

        }
    }
}
