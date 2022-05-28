using System;

namespace _01_Convert_Meters
{
    class Program
    {
        static void Main(string[] args)
        {
            int nMeters;
            double dKilometers;

            nMeters = int.Parse(Console.ReadLine());

            dKilometers = (double)nMeters / 1000.0D;

            Console.WriteLine("{0:F2}", dKilometers);


        }
    }
}
