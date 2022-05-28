using System;

namespace _08._Basketball
{
    class Program
    {
        static void Main(string[] args)
        {

            double dTax, dSneakers, dShorts, dBall, dAccessories, dTotal;

            dTax = (double)int.Parse(Console.ReadLine());
            dSneakers = dTax * 0.6;
            dShorts = dSneakers * 0.8;
            dBall = dShorts * 0.25;
            dAccessories = dBall * 0.2;

            dTotal = dTax + dSneakers + dShorts + dBall + dAccessories;

            Console.WriteLine(dTotal);

        }
    }
}
