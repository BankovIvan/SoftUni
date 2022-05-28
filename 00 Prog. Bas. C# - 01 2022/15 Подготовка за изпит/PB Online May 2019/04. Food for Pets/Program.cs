using System;

namespace _04._Food_for_Pets
{
    class Program
    {
        static void Main(string[] args)
        {

            int i = 1, nDaysAmount = 0, nFoodDogDay = 0, nFoodCatDay = 0;
            double dFoodAmount = 0.0, dFoodDogTotal = 0.0, dFoodCatTotal = 0.0, dFoodBiscuitsTotal = 0.0, dFoodAllTotal = 0.0;

            nDaysAmount = int.Parse(Console.ReadLine());
            dFoodAmount = double.Parse(Console.ReadLine());

            while(i <= nDaysAmount)
            {
                nFoodDogDay = int.Parse(Console.ReadLine());
                nFoodCatDay = int.Parse(Console.ReadLine());

                dFoodDogTotal += nFoodDogDay;
                dFoodCatTotal += nFoodCatDay;

                if(i % 3 == 0)
                {
                    dFoodBiscuitsTotal += (double)(nFoodDogDay + nFoodCatDay) * 0.1;
                }

                i++;

            }

            dFoodAllTotal = dFoodDogTotal + dFoodCatTotal;

            Console.WriteLine("Total eaten biscuits: {0:F0}gr.", dFoodBiscuitsTotal);
            Console.WriteLine("{0:F2}% of the food has been eaten.", dFoodAllTotal * 100.0 / dFoodAmount);
            Console.WriteLine("{0:F2}% eaten from the dog.", dFoodDogTotal * 100.0 / dFoodAllTotal);
            Console.WriteLine("{0:F2}% eaten from the cat.", dFoodCatTotal * 100.0 / dFoodAllTotal);

        }
    }
}
