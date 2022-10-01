/////////////////////////////////////////////////////////////////////////////////////////
///
///   SOFTUNI JUDGE EXPECTS PROJET FILE TO BE NAMED 05_Special_Cars (NO SPACES) !!!
///   
///   DOES NOT WORK WITH PROJET FILE NAMED 05 Special Cards !!!
///
/////////////////////////////////////////////////////////////////////////////////////////

namespace CarManufacturer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    //using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> lstTires = GetTires();
            List<Engine> lstEngines = GetEngines();
            List<Car> lstCars = GetCars(lstEngines, lstTires);

            foreach(var specialCar in lstCars)
            {
                if(specialCar.Year >= 2017 && specialCar.Engine.HorsePower > 330)
                {
                    double TyrePressure = 0.0;
                    foreach(var w in specialCar.Tires)
                    {
                        TyrePressure += w.Pressure;
                    }

                    if(TyrePressure >= 9.0  && TyrePressure <= 10.0)
                    {
                        specialCar.Drive(20);
                        Console.WriteLine(specialCar.WhoAmI());
                    }
                }
            }


        }

        private static List<Car> GetCars(List<Engine> lstEngines, List<Tire[]> lstTires)
        {
            List<Car> ret = new List<Car>();
            while (true)
            {
                string[] sData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (sData[0] == "Show" && sData[1] == "special")
                {
                    break;
                }

                int nEngineIndex = int.Parse(sData[5]);
                int nTireIndex = int.Parse(sData[6]);

                ret.Add(new Car(
                                sData[0], 
                                sData[1], 
                                int.Parse(sData[2]), 
                                double.Parse(sData[3]), 
                                double.Parse(sData[4]),
                                lstEngines[nEngineIndex],
                                lstTires[nTireIndex]
                                )
                        );

            }

            return ret;

        }

        private static List<Engine> GetEngines()
        {
            List<Engine> ret = new List<Engine>();
            while (true)
            {
                string[] sData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (sData[0] == "Engines" && sData[1] == "done")
                {
                    break;
                }

                ret.Add(new Engine(int.Parse(sData[0]), double.Parse(sData[1])));

            }

            return ret;
        }

        private static List<Tire[]> GetTires()
        {
            List<Tire[]> ret = new List<Tire[]>();
            while (true)
            {
                string[] sData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (sData[0] == "No" && sData[1] == "more" && sData[2] == "tires")
                {
                    break;
                }

                ret.Add(new Tire[] {
                                new Tire(int.Parse(sData[0]), double.Parse(sData[1])),
                                new Tire(int.Parse(sData[2]), double.Parse(sData[3])),
                                new Tire(int.Parse(sData[4]), double.Parse(sData[5])),
                                new Tire(int.Parse(sData[6]), double.Parse(sData[7]))
                });

            }

            return ret;

        }
    }
}