using System;

namespace _01_Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j, nValueLeft = 0, nValueRight = 0, nFirstDimension = int.Parse(Console.ReadLine());
            int[][] arrNumbers = new int[nFirstDimension][];
            char[] arrSplit = { ',', ' ' };
            //string[] arrInput;

            for (i = 0; i < nFirstDimension; i++)
            {
                arrNumbers[i] = Array.ConvertAll(
                    Console.ReadLine().Split(arrSplit, StringSplitOptions.RemoveEmptyEntries),
                    new Converter<string, int>(int.Parse));
            }

            for(i = 0, j = nFirstDimension - 1; i < nFirstDimension; i++, j--)
            {
                nValueLeft += arrNumbers[i][i];
                nValueRight += arrNumbers[i][j];
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(Math.Abs(nValueLeft - nValueRight));
            Console.ResetColor();

        }
    }
}
