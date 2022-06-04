using System;

namespace _4._Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j, nStart, nMid, nEnd;
            int[] arrSequence;

            arrSequence = Array.ConvertAll(
                            Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                            new Converter<string, int>(int.Parse)
                        );

            nStart = arrSequence.Length / 4;
            nMid = arrSequence.Length / 2;
            nEnd = (arrSequence.Length / 4) * 3;

            for(i = nStart-1, j = nStart; i >= 0; i--, j++)
            {
                Console.Write("{0} ", arrSequence[i] + arrSequence[j]);
            }

            for (i = arrSequence.Length-1, j = nMid; i >= nEnd; i--, j++)
            {
                Console.Write("{0} ", arrSequence[i] + arrSequence[j]);
            }

            Console.WriteLine();

        }
    }
}
