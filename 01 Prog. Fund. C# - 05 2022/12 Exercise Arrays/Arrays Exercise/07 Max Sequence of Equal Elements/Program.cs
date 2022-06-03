using System;

namespace _07_Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrSequence;
            int i, j, nCurrentLength, nCurrentStart, nMaxLength, nMaxStart;

            arrSequence = Array.ConvertAll(
                Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                new Converter<string, int>(int.Parse)
                                    );
            
            nCurrentLength = 0;
            nCurrentStart = 0;
            nMaxLength = 0;
            nMaxStart = 0;

            for(i = 1; i < arrSequence.Length; i++)
            {
                if(arrSequence[i] == arrSequence[i-1])
                {
                    nCurrentLength++;

                    if(nCurrentLength > nMaxLength)
                    {
                        nMaxLength = nCurrentLength;
                        nMaxStart = nCurrentStart;
                    }

                }
                else
                {
                    nCurrentLength = 0;
                    nCurrentStart = i;
                }

            }

            nMaxLength += nMaxStart;
            for (i = nMaxStart; i <= nMaxLength; i++ )
            {
                Console.Write("{0} ", arrSequence[i]);
            }

            Console.WriteLine();

        }
    }
}
