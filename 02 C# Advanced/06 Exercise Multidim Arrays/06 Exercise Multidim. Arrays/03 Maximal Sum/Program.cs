using System;

namespace _03_Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j, nMaxSum = int.MinValue, nCurrentSum = 0, nRows, nCols, nMaxRow = 0, nMaxCol = 0;
            int[] arrDim = Array.ConvertAll(
                    Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                    new Converter<string, int>(int.Parse));
            int[][] arrMatrix = new int[arrDim[0]][];

            for (i = 0; i < arrDim[0]; i++)
            {
                arrMatrix[i] = Array.ConvertAll(
                    Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                    new Converter<string, int>(int.Parse));
            }

            nRows = arrDim[0] - 2;
            nCols = arrDim[1] - 2;

            for (i = 0; i < nRows; i++)
            {
                for (j = 0; j < nCols; j++)
                {
                    nCurrentSum = SumSubMatrix(arrMatrix, i, j, 3, 3);
                    if(nMaxSum < nCurrentSum)
                    {
                        nMaxSum = nCurrentSum;
                        nMaxRow = i;
                        nMaxCol = j;
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Sum = {0}", nMaxSum);
            Console.ResetColor();

            PrintSubMatrix(arrMatrix, nMaxRow, nMaxCol, 3, 3);

        }

        private static int SumSubMatrix(int[][] arrMatrix, int nStartRow, int nStartCol, int nNumRows, int nNumCols)
        {
            int i, j;
            int nEndRow = nStartRow + nNumRows;
            int nEndCol = nStartCol + nNumCols;
            int nSum = 0;

            for (i = nStartRow; i < nEndRow && i < arrMatrix.Length; i++)
            {
                for(j = nStartCol; j < nEndCol && j < arrMatrix[i].Length; j++)
                {
                    nSum += arrMatrix[i][j];
                }
            }

            return nSum;
        
        }

        private static void PrintSubMatrix(int[][] arrMatrix, int nStartRow, int nStartCol, int nNumRows, int nNumCols)
        {
            int i;
            int nEndRow = nStartRow + nNumRows;
            int[] arrRow = new int[nNumCols];

            for (i = nStartRow; i < nEndRow && i < arrMatrix.Length; i++)
            {
                Array.Copy(arrMatrix[i], nStartCol, arrRow, 0, nNumCols);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(String.Join(' ', arrRow));
                Console.ResetColor();
            }

            return;

        }

    }
}
