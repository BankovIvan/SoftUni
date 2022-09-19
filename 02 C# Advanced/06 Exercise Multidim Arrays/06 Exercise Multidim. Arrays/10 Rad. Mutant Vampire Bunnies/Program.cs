using System;

namespace _10_Rad._Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j, nRowCurrent = 0, nColCurrent = 0, nRowNext = 0, nColNext = 0;
            int[] nRows = Array.ConvertAll(
                    Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                    new Converter<string, int>(int.Parse));
            char[][] arrMatrix = new char[nRows[0]][];
            string sMoves;

            for (i = 0; i < arrMatrix.Length; i++)
            {
                arrMatrix[i] = Console.ReadLine().ToCharArray();
            }

            sMoves = Console.ReadLine();

            //Starting point
            for (i = 0; i < arrMatrix.Length; i++)
            {
                for (j = 0; j < arrMatrix[i].Length; j++)
                {
                    if (arrMatrix[i][j] == 'P')
                    {
                        nRowCurrent = i;
                        nColCurrent = j;
                    }
                }
            }

            for(i = 0; i < sMoves.Length; i++)
            {

                if (sMoves[i] == 'L')
                {
                    nRowNext = nRowCurrent;
                    nColNext = nColCurrent - 1;
                }
                else if (sMoves[i] == 'R')
                {
                    nRowNext = nRowCurrent;
                    nColNext = nColCurrent + 1;
                }
                else if (sMoves[i] == 'U')
                {
                    nRowNext = nRowCurrent - 1;
                    nColNext = nColCurrent;
                }
                else if (sMoves[i] == 'D')
                {
                    nRowNext = nRowCurrent + 1;
                    nColNext = nColCurrent;
                }

                arrMatrix = BangBunnie(arrMatrix);
                //PrintMatrix(arrMatrix, "");
                //Console.ReadLine();

                if (arrMatrix[nRowCurrent][nColCurrent] == 'P')
                {
                    arrMatrix[nRowCurrent][nColCurrent] = '.';
                }

                if (nRowNext < 0 || nRowNext >= arrMatrix.Length)
                {
                    PrintMatrix(arrMatrix, "");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("won: {0} {1}", nRowCurrent, nColCurrent);
                    Console.ResetColor();
                    return;
                }

                if (nColNext < 0 || nColNext >= arrMatrix[nRowNext].Length)
                {
                    PrintMatrix(arrMatrix, "");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("won: {0} {1}", nRowCurrent, nColCurrent);
                    Console.ResetColor();
                    return;
                }

                if (arrMatrix[nRowNext][nColNext] == 'B')
                {
                    PrintMatrix(arrMatrix, "");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("dead: {0} {1}", nRowNext, nColNext);
                    Console.ResetColor();
                    return;
                }

                /*
                if(arrMatrix[nRowCurrent][nColCurrent] == 'P')
                {
                    arrMatrix[nRowCurrent][nColCurrent] = '.';
                }
                */

                nRowCurrent = nRowNext;
                nColCurrent = nColNext;
                arrMatrix[nRowCurrent][nColCurrent] = 'P';

                //PrintMatrix(arrMatrix, "");
                //Console.ReadLine();
            }

        }


        private static char[][] BangBunnie(char[][] arrMatrix)
        {
            int i, j, k, l, nRow, nCol;
            char[][] arrBunnies = new char[arrMatrix.Length][];
            for (i = 0; i < arrBunnies.Length; i++)
            {
                arrBunnies[i] = new char[arrMatrix[i].Length];
            }

            for (i = 0; i < arrBunnies.Length; i++)
            {
                for (j = 0; j < arrBunnies[i].Length; j++)
                {
                    if(arrMatrix[i][j] != 'B' && arrBunnies[i][j] != 'B')
                    {
                        arrBunnies[i][j] = arrMatrix[i][j];
                        continue;
                    }

                    if(arrMatrix[i][j] == 'B')
                    {
                        arrBunnies[i][j] = 'B';

                        //UP
                        nRow = i - 1;
                        nCol = j;
                        if(nRow >= 0 && nRow < arrBunnies.Length)
                        {
                            if(nCol >= 0 && nCol < arrBunnies[nRow].Length)
                            {
                                arrBunnies[nRow][nCol] = 'B';
                            }
                        }

                        //DOWN
                        nRow = i + 1;
                        nCol = j;
                        if (nRow >= 0 && nRow < arrBunnies.Length)
                        {
                            if (nCol >= 0 && nCol < arrBunnies[nRow].Length)
                            {
                                arrBunnies[nRow][nCol] = 'B';
                            }
                        }

                        //LEFT
                        nRow = i;
                        nCol = j - 1;
                        if (nRow >= 0 && nRow < arrBunnies.Length)
                        {
                            if (nCol >= 0 && nCol < arrBunnies[nRow].Length)
                            {
                                arrBunnies[nRow][nCol] = 'B';
                            }
                        }

                        //RIGHT
                        nRow = i;
                        nCol = j + 1;
                        if (nRow >= 0 && nRow < arrBunnies.Length)
                        {
                            if (nCol >= 0 && nCol < arrBunnies[nRow].Length)
                            {
                                arrBunnies[nRow][nCol] = 'B';
                            }
                        }

                    }

                }
            }

            return arrBunnies;

        }

        private static void PrintMatrix(char[][] arrMatrix, string sDelimiter = " ")
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
