using System;

namespace _04_Tribonacci_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            long lMaxNumber;

            lMaxNumber = long.Parse(Console.ReadLine());

            //Console.WriteLine(GetNBonacciSequenceResult(3L, lMaxNumber));
            GetNBonacciSequencePrint(3L, lMaxNumber);

        }

        private static long GetNBonacciSequenceResult(long lBase, long lMaxNumber)
        {
            long[] lNumbers = new long[lBase + 1];
            long lRet = 0;
            long i, j, lBuffer;

            lNumbers[0] = 0;
            for(i = 1; i < lBase; i++)
            {
                lNumbers[i] = 1;
            }
            lNumbers[lBase] = 2;

            for(i = lBase + 1; i <= lMaxNumber; i++)
            {
                lBuffer = 0;
                for(j = 1; j < lBase; j++)
                {
                    lBuffer += lNumbers[j];
                    lNumbers[j] = lNumbers[j+1];
                }
                lBuffer += lNumbers[lBase];
                lNumbers[lBase] = lBuffer;
            }

            if(lMaxNumber <= lBase)
            {
                lRet = lNumbers[lMaxNumber];
            }
            else
            {
                lRet = lNumbers[lBase];
            }

            return lRet;

        }

        private static void GetNBonacciSequencePrint(long lBase, long lMaxNumber)
        {
            long[] lNumbers = new long[lBase + 1];
            long i, j, lBuffer;

            lNumbers[0] = 0;
            for (i = 1; i < lBase; i++)
            {
                lNumbers[i] = 1;
            }
            lNumbers[lBase] = 2;

            for (i = 1; i <= lBase && i <= lMaxNumber; i++)
            {
                Console.Write("{0} ", lNumbers[i]);
            }

            for (i = lBase + 1; i <= lMaxNumber; i++)
            {
                lBuffer = 0;
                for (j = 1; j < lBase; j++)
                {
                    lBuffer += lNumbers[j];
                    lNumbers[j] = lNumbers[j + 1];
                }
                lBuffer += lNumbers[lBase];
                lNumbers[lBase] = lBuffer;

                Console.Write("{0} ", lNumbers[lBase]);

            }

            Console.WriteLine();

        }

    }
}
