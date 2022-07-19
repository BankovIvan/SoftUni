using System;
using System.Collections.Generic;
using System.Numerics;

namespace _06_Vehicle_Catalogue
{
    class Program
    {
        class Vehicle
        {
            public string Type { get; set; }
            public string Model { get; set; }
            public string Color { get; set; }
            public int HorsePower { get; set; }

            public Vehicle()
            {

            }

            public Vehicle(string Type, string Model, string Color, int HorsePower)
            {
                this.Type = Type;
                this.Model = Model;
                this.Color = Color;
                this.HorsePower = HorsePower;
            }

            public override string ToString()
            {
                string ret;

                if (this.Type == "car")
                {
                    ret = "Type: Car" + '\n';
                }
                else
                {
                    ret = "Type: Truck" + '\n';
                }

                ret = ret + "Model: " + this.Model + '\n';
                ret = ret + "Color: " + this.Color + '\n';
                ret = ret + "Horsepower: " + this.HorsePower.ToString();

                return ret;
            }
        }

        static void Main(string[] args)
        {
            List<Vehicle> lstVehicles = new List<Vehicle>();
            string[] arrInput;
            string sInput;
            double dCarAverageHP = 0.0, dTruckAverageHP = 0.0;
            int nCarTotalHP = 0, nTruckTotalHP = 0, nCarsTotal = 0, nTrucksTotal = 0;

            while (true)
            {
                arrInput = Console.ReadLine().Split(' ');
                if (arrInput[0] == "End")
                {
                    break;
                }

                lstVehicles.Add(new Vehicle(arrInput[0], arrInput[1], arrInput[2], int.Parse(arrInput[3])));

            }

            while (true)
            {
                sInput = Console.ReadLine();
                if (sInput == "Close the Catalogue")
                {
                    break;
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(lstVehicles.Find(x => sInput == x.Model));
                Console.ResetColor();

            }

            foreach (Vehicle v in lstVehicles)
            {
                if (v.Type == "car")
                {
                    nCarsTotal++;
                    nCarTotalHP += v.HorsePower;
                }
                else
                {
                    nTrucksTotal++;
                    nTruckTotalHP += v.HorsePower;
                }
            }

            if (nCarsTotal > 0)
            {
                dCarAverageHP = (double)nCarTotalHP / (double)nCarsTotal;
            }

            if (nTrucksTotal > 0)
            {
                dTruckAverageHP = (double)nTruckTotalHP / (double)nTrucksTotal;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Cars have average horsepower of: {0:F2}.", dCarAverageHP);
            Console.WriteLine("Trucks have average horsepower of: {0:F2}.", dTruckAverageHP);
            Console.ResetColor();

        }
    }
}