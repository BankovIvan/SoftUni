using System;

namespace _05_Square_with_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j, nSum = 0, nMaxValue = int.MinValue, nMaxRow = 0, nMaxCol = 0, nRowsCount, nColsCount;
            int[] arrInput = Array.ConvertAll(
                    Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries),
                    new Converter<string, int>(int.Parse));
            int[,] arrNumbers = new int[arrInput[0], arrInput[1]];

            for (i = 0; i < arrNumbers.GetLength(0); i++)
            {
                arrInput = Array.ConvertAll(
                    Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries),
                    new Converter<string, int>(int.Parse));

                for (j = 0; j < arrNumbers.GetLength(1); j++)
                {
                    arrNumbers[i, j] = arrInput[j];
                }
            }

            nRowsCount = arrNumbers.GetLength(0) - 1;
            nColsCount = arrNumbers.GetLength(1) - 1;

            for (i = 0; i < nRowsCount; i++)
            {
                for (j = 0; j < nColsCount; j++)
                {
                    nSum = arrNumbers[i, j] + arrNumbers[i+1, j] + arrNumbers[i, j+1] + arrNumbers[i+1, j+1];
                    if(nMaxValue < nSum)
                    {
                        nMaxValue = nSum;
                        nMaxRow = i;
                        nMaxCol = j;
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("{0} {1}", arrNumbers[nMaxRow, nMaxCol], arrNumbers[nMaxRow, nMaxCol+1]);
            Console.WriteLine("{0} {1}", arrNumbers[nMaxRow+1, nMaxCol], arrNumbers[nMaxRow+1, nMaxCol + 1]);
            Console.WriteLine(nMaxValue);
            Console.ResetColor();

        }
    }
}
