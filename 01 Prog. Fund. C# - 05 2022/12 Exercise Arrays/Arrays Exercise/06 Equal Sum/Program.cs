using System;

namespace _06_Equal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrEqualSums;
            int nSumLeft, nSumRight, i, j;

            arrEqualSums = Array.ConvertAll(
                            Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                            new Converter<string, int>(int.Parse)
                                                );

            for(i = 0; i < arrEqualSums.Length; i++)
            {
                nSumLeft = 0;
                nSumRight = 0;

                for (j = 0; j < i; j++)
                {
                    nSumLeft += arrEqualSums[j];
                }

                for (j = i + 1; j < arrEqualSums.Length; j++)
                {
                    nSumRight += arrEqualSums[j];
                }

                if(nSumLeft == nSumRight)
                {
                    Console.WriteLine(i);
                    return;
                }

            }

            Console.WriteLine("no");

        }
    }
}
