using System;

namespace _02_Pounds_to_Dollars
{
    class Program
    {
        static void Main(string[] args)
        {
            double dPounds, dDollars;

            dPounds = double.Parse(Console.ReadLine());

            dDollars = dPounds * 1.31D;

            Console.WriteLine("{0:F3}", dDollars);

        }
    }
}
