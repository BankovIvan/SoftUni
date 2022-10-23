namespace _02_Rally_Racing
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            int nRows = int.Parse(Console.ReadLine());
            string sRacingNumber = Console.ReadLine().Trim();
            char[][] arrTrack = new char[nRows][];

            int nCurRow = 0, nCurCol = 0, nDistance = 0;
            string sCommand;

            //Read track;
            for(int i = 0; i < nRows; i++)
            {
                arrTrack[i] = Array.ConvertAll(
                    Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                    new Converter<string, char>(char.Parse));
            }

            arrTrack[0][0] = 'C';

            ///////////////////////////////////////////////////////////////////////////////////////////
            //Console.ForegroundColor = ConsoleColor.DarkYellow;
            //for (int i = 0; i < arrTrack.Length; i++) Console.WriteLine(String.Join(' ', arrTrack[i]));
            //Console.ResetColor();
            ///////////////////////////////////////////////////////////////////////////////////////////

            //Read commands and move;
            while ((sCommand = Console.ReadLine()) != "End")
            {
                if(MoveCar(ref arrTrack, ref nCurRow, ref nCurCol, ref nDistance, sCommand))
                {
                    break;
                }
                ///////////////////////////////////////////////////////////////////////////////////////////
                //Console.ForegroundColor = ConsoleColor.DarkYellow;
                //for (int i = 0; i < arrTrack.Length; i++) Console.WriteLine(String.Join(' ', arrTrack[i]));
                //Console.ResetColor();
                ///////////////////////////////////////////////////////////////////////////////////////////
            }

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            if(sCommand == "End")
            {
                Console.WriteLine("Racing car {0} DNF.", sRacingNumber);
            }
            else
            {
                Console.WriteLine("Racing car {0} finished the stage!", sRacingNumber);
            }
            Console.WriteLine("Distance covered {0} km.", nDistance);
            for (int i = 0; i < arrTrack.Length; i++) Console.WriteLine(new string(arrTrack[i]));
            Console.ResetColor();

        }

        private static bool MoveCar(ref char[][] arrTrack, ref int nCurRow, ref int nCurCol, ref int nDistance, string sCommand)
        {
            bool ret = false;

            arrTrack[nCurRow][nCurCol] = '.';

            switch (sCommand)
            {
                case "left":
                    //nCurRow;
                    nCurCol--;
                    break;
                case "up":
                    nCurRow--;
                    //nCurCol;
                    break;
                case "right":
                    //nCurRow;
                    nCurCol++;
                    break;
                case "down":
                    nCurRow++;
                    //nCurCol;
                    break;
                default:
                    break;
            }

            if (arrTrack[nCurRow][nCurCol] == 'T')
            {
                arrTrack[nCurRow][nCurCol] = '.';
                FindOtherEnd(arrTrack,  ref nCurRow, ref nCurCol);
                arrTrack[nCurRow][nCurCol] = 'C';
                nDistance += 30;
            }
            else if(arrTrack[nCurRow][nCurCol] == '.')
            {
                arrTrack[nCurRow][nCurCol] = 'C';
                nDistance += 10;
            }
            else if (arrTrack[nCurRow][nCurCol] == 'F')
            {
                ret = true;
                arrTrack[nCurRow][nCurCol] = 'C';
                nDistance += 10;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Unexpected racing track element value!");
            }

            return ret;

        }

        private static void FindOtherEnd(char[][] arrTrack, ref int nCurRow, ref int nCurCol)
        {
            //Find tunnel ends;
            for (int i = 0; i < arrTrack.Length; i++)
            {
                for (int j = 0; j < arrTrack[i].Length; j++)
                {
                    if (arrTrack[i][j] == 'T')
                    {
                        nCurRow = i;
                        nCurCol = j;
                        return;

                    }
                }
            }

            throw new ArgumentOutOfRangeException("The other end of the tunnel \'T\' is missing!");

            return;
        }
    }
}
