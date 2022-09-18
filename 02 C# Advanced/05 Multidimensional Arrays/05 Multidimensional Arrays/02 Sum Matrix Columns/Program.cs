using System;

namespace _02_Sum_Matrix_Columns
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j, nSum = 0;
            int[] arrInput = Array.ConvertAll(
                    Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries),
                    new Converter<string, int>(int.Parse));
            int[,] arrNumbers = new int[arrInput[0], arrInput[1]];

            for (i = 0; i < arrNumbers.GetLength(0); i++)
            {
                arrInput = Array.ConvertAll(
                    Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                    new Converter<string, int>(int.Parse));

                for (j = 0; j < arrNumbers.GetLength(1); j++)
                {
                    arrNumbers[i, j] = arrInput[j];
                }
            }

            for (i = 0; i < arrNumbers.GetLength(1); i++)
            {
                nSum = 0;
                for (j = 0; j < arrNumbers.GetLength(0); j++)
                {
                    nSum += arrNumbers[j, i];
                }

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(nSum);
                Console.ResetColor();

            }

        }
    }
}
