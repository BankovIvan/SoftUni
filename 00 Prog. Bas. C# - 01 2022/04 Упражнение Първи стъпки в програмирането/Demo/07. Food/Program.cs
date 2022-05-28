using System;

namespace _07._Food
{
    class Program
    {
        static void Main(string[] args)
        {

            double dChicken, dFish, dVeggie, dTotal;

            dChicken = (double)int.Parse(Console.ReadLine());
            dFish = (double)int.Parse(Console.ReadLine());
            dVeggie = (double)int.Parse(Console.ReadLine());

            dChicken *= 10.35;
            dFish *= 12.40;
            dVeggie *= 8.15;

            dTotal = dChicken + dFish + dVeggie;

            dTotal += dTotal * 0.20;

            dTotal += 2.50;

            Console.WriteLine(dTotal);

        }
    }
}
