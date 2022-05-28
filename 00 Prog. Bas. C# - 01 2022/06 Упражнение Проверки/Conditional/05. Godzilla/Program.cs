using System;

namespace _05._Godzilla
{
    class Program
    {
        static void Main(string[] args)
        {

            double dMovieBudget, dClothesPerActor, dDecorePrice, dClothesPrice, dBudgetDelta;
            int nNumActors;

            dMovieBudget = double.Parse(Console.ReadLine());
            nNumActors = int.Parse(Console.ReadLine());
            dClothesPerActor = double.Parse(Console.ReadLine());

            dDecorePrice = dMovieBudget * 0.10;
            dClothesPrice = (double)nNumActors * dClothesPerActor;

            if(nNumActors > 150)
            {
                dClothesPrice *= 0.90;
            }

            dBudgetDelta = dMovieBudget - (dDecorePrice + dClothesPrice);

            if(dBudgetDelta < 0.0)
            {
                dBudgetDelta *= -1.0;
                Console.WriteLine("Not enough money!");
                Console.WriteLine("Wingard needs {0:F2} leva more.", dBudgetDelta);
            }
            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine("Wingard starts filming with {0:F2} leva left.", dBudgetDelta);
            }

        }
    }
}
