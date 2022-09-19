using System;

namespace _08_Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j, nActive = 0, nSum = 0;
            int nRows = int.Parse(Console.ReadLine());
            int[][] arrMatrix = new int[nRows][];
            int[] arrBombs;

            for (i = 0; i < nRows; i++)
            {
                arrMatrix[i] = Array.ConvertAll(
                    Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                    new Converter<string, int>(int.Parse));
            }

            arrBombs = Array.ConvertAll(
                    Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries),
                    new Converter<string, int>(int.Parse));

            //PrintMatrix(arrMatrix);
            //Console.ReadLine();

            for (i = 0; i < arrBombs.Length; i = i + 2)
            {
                BangBomb(ref arrMatrix, arrBombs[i], arrBombs[i + 1]);
                //PrintMatrix(arrMatrix);
                //Console.ReadLine();
            }

            for (i = 0; i < arrMatrix.Length; i++)
            {
                for(j = 0; j < arrMatrix[i].Length; j++)
                {
                    if(arrMatrix[i][j] > 0)
                    {
                        nActive++;
                        nSum += arrMatrix[i][j];
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Alive cells: {0}", nActive);
            Console.WriteLine("Sum: {0}", nSum);
            Console.ResetColor();
            PrintMatrix(arrMatrix);

        }

        private static void BangBomb(ref int[][] arrMatrix, int nRow, int nCol)
        {
            int i, j, nStartRow, nEndRow, nStartCol, nEndCol;
            int nDamage = arrMatrix[nRow][nCol];

            if (nDamage <= 0)
            {
                return;
            }

            nStartRow = nRow - 1;
            nEndRow = nRow + 1;
            nStartCol = nCol - 1;
            nEndCol = nCol + 1;

            if (nStartRow < 0)
            {
                nStartRow = 0;
            }
            
            if(nEndRow >= arrMatrix.Length)
            {
                nEndRow = arrMatrix.Length - 1;
            }

            if (nStartCol < 0)
            {
                nStartCol = 0;
            }

            if (nEndCol >= arrMatrix[nRow].Length)
            {
                nEndCol = arrMatrix[nRow].Length - 1;
            }

            arrMatrix[nRow][nCol] = 0;
            for (i = nStartRow; i <= nEndRow; i++)
            {
                for(j = nStartCol; j <= nEndCol; j++)
                {
                    if(arrMatrix[i][j] > 0)
                    {
                        arrMatrix[i][j] -= nDamage;
                    }
                }
            }

        }

        private static void PrintMatrix(int[][] arrMatrix, string sDelimiter = " ")
        {
            int i;

            Console.ForegroundColor = ConsoleColor.DarkYellow;

            for (i = 0; i < arrMatrix.Length; i++)
            {
                Console.WriteLine(String.Join(sDelimiter, arrMatrix[i]));
            }

            Console.ResetColor();
        }
    }
}
