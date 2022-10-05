namespace _07_Raw_Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> lstCars = new List<Car>();

            int nRepeat = int.Parse(Console.ReadLine());
            for(int i = 0; i < nRepeat; i++)
            {
                string[] arrCars = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                lstCars.Add(new Car(arrCars[0],
                                    int.Parse(arrCars[1]),
                                    int.Parse(arrCars[2]),
                                    int.Parse(arrCars[3]),
                                    arrCars[4],
                                    double.Parse(arrCars[5]),
                                    int.Parse(arrCars[6]),
                                    double.Parse(arrCars[7]),
                                    int.Parse(arrCars[8]),
                                    double.Parse(arrCars[9]),
                                    int.Parse(arrCars[10]),
                                    double.Parse(arrCars[11]),
                                    int.Parse(arrCars[12])
                                    ));

            }

            string sCommand = Console.ReadLine();
            if(sCommand == "fragile")
            {
                foreach(var v in lstCars.Where(x => x.Cargo.Type == "fragile").Where(x => x.Tires.Any(y => y.Pressure < 1.0)))
                {
                    Console.WriteLine(v.Model);
                }
            }
            else if(sCommand == "flammable")
            {
                foreach (var v in lstCars.Where(x => x.Cargo.Type == "flammable").Where(x => x.Engine.Power > 250))
                {
                    Console.WriteLine(v.Model);
                }
            }
        }
    }
}
