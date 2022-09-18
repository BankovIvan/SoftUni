using System;

namespace _07_Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j, nSize = int.Parse(Console.ReadLine());
            long[][] arrPascal = new long[nSize][];

            arrPascal[0] = new long[] { 1 };
            for(i = 1; i < nSize; i++)
            {
                arrPascal[i] = new long[i + 1];
                for(j = 1; j < i; j++)
                {
                    arrPascal[i][j] = arrPascal[i-1][j-1] + arrPascal[i-1][j];
                }
                arrPascal[i][0] = 1;
                arrPascal[i][i] = 1;
            }

            for (i = 0; i < nSize; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(string.Join(' ', arrPascal[i]));
                Console.ResetColor();
            }

        }
    }
}
