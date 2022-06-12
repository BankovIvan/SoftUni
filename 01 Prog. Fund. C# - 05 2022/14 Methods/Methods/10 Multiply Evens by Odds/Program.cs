using System;
using System.Text;

namespace _10_Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int nNumbers;

            nNumbers = int.Parse(Console.ReadLine());

            PrintSumsOfEvensAndOdds(Math.Abs(nNumbers));

        }

        private static void PrintSumsOfEvensAndOdds(int nNumbers)
        {
            int nOdds, nEvens;

            nOdds = GetSumOfOddDigits(nNumbers);
            nEvens = GetSumOfEvenDigits(nNumbers);

            Console.WriteLine(nOdds * nEvens);
        }

        private static int GetSumOfOddDigits(int nNumbers)
        {
            int nRet, nDigit;
            
            nRet = 0;

            for (; nNumbers > 0; nNumbers /= 10)
            {
                nDigit = nNumbers % 10;
                if ((nDigit & 1) == 0)
                {
                    nRet += nDigit;
                }
            }

            return nRet;

        }

        private static int GetSumOfEvenDigits(int nNumbers)
        {
            int nRet, nDigit;

            nRet = 0;

            for (; nNumbers > 0; nNumbers /= 10)
            {
                nDigit = nNumbers % 10;
                if ((nDigit & 1) == 1)
                {
                    nRet += nDigit;
                }
            }

            return nRet;

        }
    }
}
