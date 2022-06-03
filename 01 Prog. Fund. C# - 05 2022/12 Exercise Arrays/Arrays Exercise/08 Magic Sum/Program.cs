using System;

namespace _08_Magic_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrSequence;
            int i, j, nMagicSum;

            arrSequence = Array.ConvertAll(
                Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                new Converter<string, int>(int.Parse)
                                    );

            nMagicSum = int.Parse(Console.ReadLine());

            for(i = 0; i < arrSequence.Length; i++)
            {
                for (j = i + 1; j < arrSequence.Length; j++)
                {
                    if((arrSequence[i] + arrSequence[j]) == nMagicSum)
                    {
                        Console.WriteLine("{0} {1}", arrSequence[i], arrSequence[j]);
                        break;
                    }
                }
            }

        }
    }
}
