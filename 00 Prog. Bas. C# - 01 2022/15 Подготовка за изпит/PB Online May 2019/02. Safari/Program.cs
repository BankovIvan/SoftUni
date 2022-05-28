using System;

namespace _02._Safari
{
    class Program
    {
        static void Main(string[] args)
        {

            double dBudgetAvailable = 0.0, dNightsPrice = 0.0, dBudgetSpent = 0.0;
            int nNightsAmount = 0, nBudgetAddons = 0;

            dBudgetAvailable = double.Parse(Console.ReadLine());
            nNightsAmount = int.Parse(Console.ReadLine());
            dNightsPrice = double.Parse(Console.ReadLine());
            nBudgetAddons = int.Parse(Console.ReadLine());

            if(nNightsAmount > 7)
            {
                dNightsPrice *= 0.95;
            }

            dBudgetSpent = (double)nNightsAmount * dNightsPrice + dBudgetAvailable * (double)nBudgetAddons / 100.0;
            dBudgetAvailable = dBudgetAvailable - dBudgetSpent;

            if (dBudgetAvailable >= 0)
            {
                Console.WriteLine("Ivanovi will be left with {0:F2} leva after vacation.", dBudgetAvailable);
            }
            else
            {
                dBudgetAvailable *= -1.0;
                Console.WriteLine("{0:F2} leva needed.", dBudgetAvailable);
            }

        }
    }
}
