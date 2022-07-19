using System;
using System.Collections.Generic;
using System.Numerics;

namespace _M03_Speed_Racing
{
    class Car
    {
        public string Model { get; set; }
        public double Fuel { get; set; }
        public double Consumption { get; set; }
        public double Distance { get; set; }

        public Car(string Model, string Fuel, string Consumption)
        {
            this.Model = Model;
            this.Fuel = double.Parse(Fuel);
            this.Consumption = double.Parse(Consumption);
            this.Distance = 0.0;
        }

        public override string ToString()
        {
            return string.Format("{0} {1:F2} {2:F0}", this.Model, this.Fuel, this.Distance);
        }

        public void Drive(double Distance)
        {
            double dSpentFuel;

            dSpentFuel = Distance * this.Consumption;

            if (dSpentFuel > this.Fuel)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Insufficient fuel for the drive");
                Console.ResetColor();
                return;
            }

            this.Fuel -= dSpentFuel;
            this.Distance += Distance;

        }

    }

    class Program
    {
        static void Main(string[] args)
        {

            List<Car> lstCars = new List<Car>();
            string[] arrInput;
            int i, nRepeat;

            nRepeat = int.Parse(Console.ReadLine());

            for (i = 0; i < nRepeat; i++)
            {
                arrInput = Console.ReadLine().Split(' ');
                lstCars.Add(new Car(arrInput[0], arrInput[1], arrInput[2]));
            }

            while (true)
            {
                arrInput = Console.ReadLine().Split(' ');
                if (arrInput[0] == "End")
                {
                    break;
                }

                lstCars.Find(x => x.Model == arrInput[1]).Drive(double.Parse(arrInput[2]));

            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.WriteLine("Hello World!");
            lstCars.ForEach(x => Console.WriteLine(x));
            Console.ResetColor();

        }
    }
}