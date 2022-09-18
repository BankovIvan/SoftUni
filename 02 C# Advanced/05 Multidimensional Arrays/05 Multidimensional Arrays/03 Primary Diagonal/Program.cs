using System;

namespace _03_Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j, nSum = 0, nSize = int.Parse(Console.ReadLine());
            int[] arrInput;
            int[,] arrNumbers = new int[nSize, nSize];

            for (i = 0; i < nSize; i++)
            {
                arrInput = Array.ConvertAll(
                    Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                    new Converter<string, int>(int.Parse));

                for (j = 0; j < nSize; j++)
                {
                    arrNumbers[i, j] = arrInput[j];
                }
            }

            for (i = 0; i < nSize; i++)
            {
                nSum += arrNumbers[i, i];
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(nSum);
            Console.ResetColor();

        }
    }
}
