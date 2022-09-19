using System;

namespace _09_Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j, nRowCurrent = 0, nColCurrent = 0, nRowNext = 0, nColNext = 0, nTotalCoals = 0, nCurrentCoals = 0;
            int nRows = int.Parse(Console.ReadLine());
            string[][] arrMatrix = new string[nRows][];
            string[] arrMoves = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (i = 0; i < nRows; i++)
            {
                arrMatrix[i] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            for(i = 0; i < arrMatrix.Length; i++)
            {
                for (j = 0; j < arrMatrix[i].Length; j++)
                {
                    if(arrMatrix[i][j] == "s")
                    {
                        nRowCurrent = i;
                        nColCurrent = j;
                    }
                    else if (arrMatrix[i][j] == "c")
                    {
                        nTotalCoals++;
                    }
                }
            }

            for(i = 0; i < arrMoves.Length; i++)
            {
                if(arrMoves[i] == "left")
                {
                    nRowNext = nRowCurrent;
                    nColNext = nColCurrent - 1;
                }
                else if (arrMoves[i] == "right")
                {
                    nRowNext = nRowCurrent;
                    nColNext = nColCurrent + 1;
                }
                else if (arrMoves[i] == "up")
                {
                    nRowNext = nRowCurrent - 1;
                    nColNext = nColCurrent;
                }
                else if (arrMoves[i] == "down")
                {
                    nRowNext = nRowCurrent + 1;
                    nColNext = nColCurrent;
                }

                if(nRowNext >= 0 && nRowNext < arrMatrix.Length)
                {
                    if(nColNext >= 0 && nColNext < arrMatrix[nRowNext].Length)
                    {
                        nRowCurrent = nRowNext;
                        nColCurrent = nColNext;
                        if(arrMatrix[nRowCurrent][nColCurrent] == "e")
                        {
                            Console.WriteLine("Game over! ({0}, {1})", nRowCurrent, nColCurrent);
                            return;
                        }
                        else if(arrMatrix[nRowCurrent][nColCurrent] == "c")
                        {
                            nCurrentCoals++;
                            arrMatrix[nRowCurrent][nColCurrent] = "*";
                            if(nCurrentCoals >= nTotalCoals)
                            {
                                Console.WriteLine("You collected all coals! ({0}, {1})", nRowCurrent, nColCurrent);
                                return;
                            }
                        }

                    }
                }


            }

            Console.WriteLine("{0} coals left. ({1}, {2})", nTotalCoals - nCurrentCoals, nRowCurrent, nColCurrent);

        }

    }
}
