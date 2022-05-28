using System;

namespace _05._Supplies_for_School
{
    class Program
    {
        static void Main(string[] args)
        {

            double dPencils, dMarkers, dCleaningAgent, dDiscount, dTotalSum;

            dPencils = double.Parse(Console.ReadLine());
            dMarkers = double.Parse(Console.ReadLine());
            dCleaningAgent = double.Parse(Console.ReadLine());
            dDiscount = double.Parse(Console.ReadLine());

            dPencils *= 5.80;
            dMarkers *= 7.20;
            dCleaningAgent *= 1.20;
            dDiscount = 1 - (dDiscount / 100);

            dTotalSum = (dPencils + dMarkers + dCleaningAgent) * dDiscount;

            Console.WriteLine(dTotalSum);

        }
    }
}
