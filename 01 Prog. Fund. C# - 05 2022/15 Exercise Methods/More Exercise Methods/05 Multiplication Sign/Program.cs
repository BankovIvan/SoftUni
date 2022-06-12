using System;

namespace _05_Multiplication_Sign
{
    class Program
    {
        static void Main(string[] args)
        {
            double nNum1, nNum2, nNum3;

            nNum1 = double.Parse(Console.ReadLine());
            nNum2 = double.Parse(Console.ReadLine());
            nNum3 = double.Parse(Console.ReadLine());

            PrintPositiveOrNegative(nNum1, nNum2, nNum3);


        }

        private static void PrintPositiveOrNegative(double nNum1, double nNum2, double nNum3)
        {
            bool bPositive = true;

            if (nNum1 < 0)
            {
                bPositive = !bPositive;
            }
            else if (nNum1 == 0)
            {
                Console.WriteLine("zero");
                return;
            }

            if (nNum2 < 0)
            {
                bPositive = !bPositive;
            }
            else if (nNum2 == 0)
            {
                Console.WriteLine("zero");
                return;
            }

            if (nNum3 < 0)
            {
                bPositive = !bPositive;
            }
            else if(nNum3 == 0)
            {
                Console.WriteLine("zero");
                return;
            }

            if (bPositive)
            {
                Console.WriteLine("positive");
            }
            else
            {
                Console.WriteLine("negative");
            }

        }
    }
}
