using System;

namespace _04_Refactoring_Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            for (int nCurrentValue = 2; nCurrentValue <= N; nCurrentValue++)
            {
                bool bPrime = true;
                for (int nDivisor = 2; nDivisor < nCurrentValue; nDivisor++)
                {
                    if (nCurrentValue % nDivisor == 0)
                    {
                        bPrime = false;
                        break;
                    }
                }
                Console.WriteLine("{0} -> {1}", nCurrentValue, (bPrime ? "true":"false"));
            }

        }
    }
}
