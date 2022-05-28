using System;

namespace _02._Deer_of_Santa
{
    class Program
    {
        static void Main(string[] args)
        {

            int nDaysAmount = 0, nFoodAmount = 0;
            double dDeer1Food = 0.0, dDeer2Food = 0.0, dDeer3Food = 0.0, dDeerTotal = 0.0;

            nDaysAmount = int.Parse(Console.ReadLine());
            nFoodAmount = int.Parse(Console.ReadLine());
            dDeer1Food = double.Parse(Console.ReadLine());
            dDeer2Food = double.Parse(Console.ReadLine());
            dDeer3Food = double.Parse(Console.ReadLine());

            dDeerTotal = (double)nDaysAmount * (dDeer1Food + dDeer2Food + dDeer3Food);

            if((double)nFoodAmount >= dDeerTotal)
            {
                Console.WriteLine("{0} kilos of food left.", Math.Floor((double)nFoodAmount - dDeerTotal));
            }
            else
            {
                Console.WriteLine("{0} more kilos of food are needed.", Math.Ceiling(dDeerTotal - (double)nFoodAmount));
            }
        }
    }
}
