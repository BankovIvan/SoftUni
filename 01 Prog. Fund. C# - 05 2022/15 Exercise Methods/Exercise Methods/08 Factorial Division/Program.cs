using System;

namespace _08_Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int nFirst, nSecond;

            nFirst = int.Parse(Console.ReadLine());
            nSecond = int.Parse(Console.ReadLine());

            Console.WriteLine("{0:F2}", MyFactoral(nFirst) / MyFactoral(nSecond));

        }

        private static double MyFactoral(int nFirst)
        {
            double dRet = (double)nFirst;


            for(nFirst--; nFirst > 1; nFirst--)
            {
                dRet *= (double)nFirst;
            }

            return dRet;

        }
    }
}
