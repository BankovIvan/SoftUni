using System;

namespace _02_Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j, nTotal = 0, nRows, nCols;
            // [0] = Rows, [1] = Cols
            int[] arrDim = Array.ConvertAll(
                    Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                    new Converter<string, int>(int.Parse));
            char[][] arrMatrix = new char[arrDim[0]][];

            for (i = 0; i < arrDim[0]; i++)
            {
                arrMatrix[i] = Array.ConvertAll(
                    Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                    new Converter<string, char>(char.Parse));
            }

            nRows = arrDim[0] - 1;
            nCols = arrDim[1] - 1;

            for (i = 0; i < nRows; i++)
            {
                for(j = 0; j < nCols; j++)
                {
                    if(arrMatrix[i][j] == arrMatrix[i][j + 1] &&
                        arrMatrix[i][j] == arrMatrix[i + 1][j] &&
                        arrMatrix[i][j] == arrMatrix[i + 1][j + 1])
                    {
                        nTotal++;
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(nTotal);
            Console.ResetColor();

        }
    }
}
