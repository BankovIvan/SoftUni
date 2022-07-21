using System;

namespace _02_Char_Mul
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrStrings;
            int i, nFirst, nSecond, nLong, nSum = 0;

            arrStrings = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            nLong = Math.Max(arrStrings[0].Length, arrStrings[1].Length);

            for (i = 0; i < nLong; i++)
            {
                nFirst = 1;
                nSecond = 1;
                if(i < arrStrings[0].Length)
                {
                    nFirst = (int)arrStrings[0][i];
                }
                if (i < arrStrings[1].Length)
                {
                    nSecond = (int)arrStrings[1][i];
                }

                nSum += nFirst * nSecond;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(nSum);
            Console.ResetColor();

        }
    }
}
