namespace _02_Wall_Destroyer
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            char[][] arrWall = new char[int.Parse(Console.ReadLine())][];
            string sCommand;
            int nCurrentRow = 0, nCurrentCol = 0, nNextRow = 0, nNextCol = 0;
            int nHoles = 0, nRods = 0;
            
            for(int i = 0; i < arrWall.Length; i++)
            {
                arrWall[i] = Console.ReadLine().ToCharArray();
            }

            for (int i = 0; i < arrWall.Length; i++)
            {
                for (int j = 0; j < arrWall[i].Length; j++)
                {
                    if(arrWall[i][j] == 'V')
                    {
                        nCurrentRow = i;
                        nCurrentCol = j;
                        arrWall[i][j] = 'V';
                        nHoles++;
                        goto LABEL_FOUND;
                    }
                }
            }

LABEL_FOUND:

            while ((sCommand = Console.ReadLine()) != "End")
            {

                //Console.ForegroundColor = ConsoleColor.Magenta;
                //foreach (var v in arrWall) Console.WriteLine(v);
                //Console.ResetColor();

                switch (sCommand)
                {
                    case "left":
                        nNextRow = nCurrentRow;
                        nNextCol = nCurrentCol-1;
                        break;
                    case "right":
                        nNextRow = nCurrentRow;
                        nNextCol = nCurrentCol + 1;
                        break;
                    case "up":
                        nNextRow = nCurrentRow - 1;
                        nNextCol = nCurrentCol;
                        break;
                    case "down":
                        nNextRow = nCurrentRow + 1;
                        nNextCol = nCurrentCol;
                        break;
                    default:
                        break;
                }

                if(nNextRow >= arrWall.Length || nNextRow < 0) continue;
                if (nNextCol >= arrWall[nNextRow].Length || nNextCol < 0) continue;

                if (arrWall[nNextRow][nNextCol] == 'R')
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Vanko hit a rod!");
                    Console.ResetColor();
                    nRods++;
                    continue;
                }

                if (arrWall[nNextRow][nNextCol] == 'C')
                {
                    arrWall[nCurrentRow][nCurrentCol] = '*';
                    arrWall[nNextRow][nNextCol] = 'E';
                    nHoles++;
                    break;
                }

                if (arrWall[nNextRow][nNextCol] == '*')
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("The wall is already destroyed at position [{0}, {1}]!", nNextRow, nNextCol);
                    Console.ResetColor();
                }
                else
                {
                    nHoles++;
                }

                arrWall[nCurrentRow][nCurrentCol] = '*';
                arrWall[nNextRow][nNextCol] = 'V';
                nCurrentRow = nNextRow;
                nCurrentCol = nNextCol;

            }

            Console.ForegroundColor = ConsoleColor.Green;

            if (sCommand == "End")
            {
                Console.WriteLine("Vanko managed to make {0} hole(s) and he hit only {1} rod(s).", nHoles, nRods);
            }
            else
            {
                Console.WriteLine("Vanko got electrocuted, but he managed to make {0} hole(s).", nHoles);
            }

            foreach(var v in arrWall)
            {
                Console.WriteLine(v);
            }

            Console.ResetColor();

        }
    }
}
