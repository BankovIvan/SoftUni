using System;

namespace _05_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, nLastDigit, nRemainingDigits, nSumOfDigits, nNumber;
            //bool bSpecial;

            nNumber = int.Parse(Console.ReadLine());
            

            for (i = 1; i <= nNumber; i++)
            {

                nRemainingDigits = i;
                nSumOfDigits = 0;

                while (nRemainingDigits > 0)
                {
                    nLastDigit = nRemainingDigits % 10;
                    nSumOfDigits += nLastDigit;

                    nRemainingDigits = nRemainingDigits / 10;

                }

                Console.WriteLine("{0} -> {1}", i, (nSumOfDigits == 5 || nSumOfDigits == 7 || nSumOfDigits == 11));

            }
        }
    }
}
