namespace _02._Pawn_Wars
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            char[][] arrBoard = new char[8][];
            int nWhiteRow = 0, nWhiteCol = 0, nBlackRow = 7, nBlackCol = 7;

            for(int i = 0; i < arrBoard.Length; i++)
            {
                arrBoard[i] = Console.ReadLine().ToCharArray();
                for(int j = 0; j < arrBoard[i].Length; j++)
                {
                    if (arrBoard[i][j] == 'w')
                    {
                        nWhiteRow = i;
                        nWhiteCol = j;
                    }
                    else if(arrBoard[i][j] == 'b')
                    {
                        nBlackRow = i;
                        nBlackCol = j;
                    }
                }
            }

            while (true)
            {
                // WHITE MOVES
                if(nWhiteRow == nBlackRow + 1)
                {
                    if(Math.Abs(nWhiteCol - nBlackCol) == 1)
                    {
                        Console.WriteLine("Game over! White capture on {0}{1}.", (char)('a' + nBlackCol), 9 - nWhiteRow);
                        return;
                    }
                }

                nWhiteRow--;

                if(nWhiteRow == 0)
                {
                    Console.WriteLine("Game over! White pawn is promoted to a queen at {0}{1}.", (char)('a' + nWhiteCol), 8 - nWhiteRow);
                    return;
                }

                // BLACK MOVES
                if (nWhiteRow == nBlackRow + 1)
                {
                    if (Math.Abs(nWhiteCol - nBlackCol) == 1)
                    {
                        Console.WriteLine("Game over! Black capture on {0}{1}.", (char)('a' + nWhiteCol), 7 - nBlackRow);
                        return;
                    }
                }

                nBlackRow++;

                if (nBlackRow == 7)
                {
                    Console.WriteLine("Game over! Black pawn is promoted to a queen at {0}{1}.", (char)('a' + nBlackCol), 8 - nBlackRow);
                    return;
                }

            }

        }
    }
}
