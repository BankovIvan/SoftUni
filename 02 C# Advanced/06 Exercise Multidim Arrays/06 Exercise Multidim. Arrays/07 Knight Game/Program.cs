using System;

namespace _07_Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j, nMaxRow = 0, nMaxCol = 0, nMaxBang = 0, nCurBang = 0, nRemoved = 0, nRows = int.Parse(Console.ReadLine());
            int[][] arrMatrix = new int[nRows][];
            //int[][] arrTest = new int[nRows][];
            string sRow;

            for (i = 0; i < nRows; i++)
            {
                arrMatrix[i] = new int[nRows];
                //arrTest[i] = new int[nRows];
                sRow = Console.ReadLine();
                for(j = 0; j < nRows; j++)
                {
                    if(sRow[j] == '0')
                    {
                        arrMatrix[i][j] = 0;
                    }
                    else
                    {
                        arrMatrix[i][j] = 1;
                    }
                }
            }

            //PrintMatrix(arrMatrix);
            //Console.ReadLine();

            while(true)
            {
                nMaxBang = 1;
                for (i = 0; i < arrMatrix.Length; i++)
                {
                    for (j = 0; j < arrMatrix[i].Length; j++)
                    {
                        nCurBang = EvaluateAdjacent(arrMatrix, i, j);
                        //arrTest[i][j] = nCurBang;
                        if (nMaxBang < nCurBang)
                        {
                            nMaxBang = nCurBang;
                            nMaxRow = i;
                            nMaxCol = j;
                        }
                    }
                }

                //PrintMatrix(arrTest);
                //Console.ForegroundColor = ConsoleColor.DarkYellow;
                //Console.WriteLine(nRemoved);
                //Console.ResetColor();
                //Console.ReadLine();

                if (nMaxBang > 1)
                {
                    arrMatrix[nMaxRow][nMaxCol] = 0;
                    nRemoved++;
                }
                else
                {
                    break;
                }

            }

            //PrintMatrix(arrMatrix);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(nRemoved);
            Console.ResetColor();

        }

        private static int EvaluateAdjacent(int[][] arrMatrix, int nRow, int nCol)
        {
            int i, j, nCount = 1;

            if(arrMatrix[nRow][nCol] == 0)
            {
                return 0;
            }
            
            i = nRow + 2;
            j = nCol + 1;
            if(i >= 0 && i < arrMatrix.Length)
            {
                if(j >= 0 && j < arrMatrix[i].Length)
                {
                    if(arrMatrix[i][j] != 0)
                    {
                        nCount++;
                    }
                }
            }

            i = nRow + 1;
            j = nCol + 2;
            if (i >= 0 && i < arrMatrix.Length)
            {
                if (j >= 0 && j < arrMatrix[i].Length)
                {
                    if (arrMatrix[i][j] != 0)
                    {
                        nCount++;
                    }
                }
            }

            i = nRow - 1;
            j = nCol + 2;
            if (i >= 0 && i < arrMatrix.Length)
            {
                if (j >= 0 && j < arrMatrix[i].Length)
                {
                    if (arrMatrix[i][j] != 0)
                    {
                        nCount++;
                    }
                }
            }

            i = nRow - 2;
            j = nCol + 1;
            if (i >= 0 && i < arrMatrix.Length)
            {
                if (j >= 0 && j < arrMatrix[i].Length)
                {
                    if (arrMatrix[i][j] != 0)
                    {
                        nCount++;
                    }
                }
            }

            i = nRow - 2;
            j = nCol - 1;
            if (i >= 0 && i < arrMatrix.Length)
            {
                if (j >= 0 && j < arrMatrix[i].Length)
                {
                    if (arrMatrix[i][j] != 0)
                    {
                        nCount++;
                    }
                }
            }

            i = nRow - 1;
            j = nCol - 2;
            if (i >= 0 && i < arrMatrix.Length)
            {
                if (j >= 0 && j < arrMatrix[i].Length)
                {
                    if (arrMatrix[i][j] != 0)
                    {
                        nCount++;
                    }
                }
            }

            i = nRow + 1;
            j = nCol - 2;
            if (i >= 0 && i < arrMatrix.Length)
            {
                if (j >= 0 && j < arrMatrix[i].Length)
                {
                    if (arrMatrix[i][j] != 0)
                    {
                        nCount++;
                    }
                }
            }

            i = nRow + 2;
            j = nCol - 1;
            if (i >= 0 && i < arrMatrix.Length)
            {
                if (j >= 0 && j < arrMatrix[i].Length)
                {
                    if (arrMatrix[i][j] != 0)
                    {
                        nCount++;
                    }
                }
            }

            return nCount;

        }

        private static void PrintMatrix(int[][] arrMatrix)
        {
            int i;

            Console.ForegroundColor = ConsoleColor.DarkYellow;

            for (i = 0; i < arrMatrix.Length; i++)
            {
                Console.WriteLine(String.Join("", arrMatrix[i]));
            }

            Console.ResetColor();
        }
    }
}
