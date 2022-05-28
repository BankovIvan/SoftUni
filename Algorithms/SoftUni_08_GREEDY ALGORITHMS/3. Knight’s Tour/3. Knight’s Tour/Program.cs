using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Program
{
    /*
    static int[,] test = {{ 1, 24, 61, 96, 3, 26, 91, 110, 5, 28, 31, 112 },
  { 62,  95,   2,  25,  92, 141,   4,  27, 114, 111,   6,  29 },
  { 23,  60,  93, 144,  97,  90, 135, 142, 109,  30, 113,  32 },
  { 94,  63,  98,  89, 140, 143, 130, 115, 136, 119, 108,   7 },
  { 59,  22, 139, 100, 129, 134, 137, 126, 107, 116,  33, 118 },
  { 64,  99,  88, 133, 138, 127, 106, 131, 120, 125,   8,  81 },
  { 21,  58,  65, 128, 101, 132, 121, 124, 105,  82, 117,  34 },
  { 46,  55, 102,  87,  66,  77, 104,  83, 122,  75,  80,   9 },
  { 57,  20,  47,  54, 103,  86, 123,  76,  79,  84,  35,  74 },
  { 42,  45,  56,  67,  50,  53,  78,  85,  70,  73,  10,  13 },
  { 19,  48,  43,  40,  17,  68,  51,  38,  15,  12,  71,  36 },
  { 44,  41,  18,  49,  52,  39,  16,  69,  72,  37,  14,  11 }};
  */

    static void Main(string[] args)
    {
        int chessBoardSize = 0;
        int[,] chessBoard;

        chessBoardSize = int.Parse(Console.ReadLine());

        if (chessBoardSize > 0) chessBoard = new int[chessBoardSize, chessBoardSize];
        else return;

        KnightTour(chessBoard);

        PrintTable(chessBoard);

        return;
    }

    private static void KnightTour(int[,] chessBoard)
    {
       int i, tmp;

        
        int currentRow = 0;
        int currentCol = 0;
        int direction = 0;
        int currentStep = 1;
        int moveCost = int.MaxValue;

        chessBoard[0, 0] = currentStep;

        while (moveCost > 0)
        {
            moveCost = 0;
            for (i = 1; i < 9; i++)
            {
                tmp = KnightMoveCost(chessBoard, currentRow, currentCol, i);
                if (tmp > 0 && (moveCost == 0 || tmp < moveCost))
                {
                    moveCost = tmp;
                    direction = i;
                } 
            }

            if(moveCost > 0 && moveCost < int.MaxValue)
            {
                MoveKnight(ref currentRow, ref currentCol, direction);
                currentStep++;
                chessBoard[currentRow, currentCol] = currentStep;

                //if(chessBoard[currentRow, currentCol] != test[currentRow, currentCol])
                //{

                    //PrintTable(chessBoard);
                //Console.WriteLine(currentRow + "---" + currentCol);
                //Console.WriteLine();
                //}


            }

        }


    }

    private static int KnightMoveCost(int[,] chessBoard, int currentRow, int currentCol, int direction)
    {
        //Move the knight to given direction;
        //Return 0 if new position is invalid;
        //Else...
        //Check all posible moves to from this position;
        //Return 1 + all possible moves;
        //Result of 1 is used to indicate full table;

        int k;
        int cost = 0;

        MoveKnight(ref currentRow, ref currentCol, direction);

        if (currentRow < 0 || currentRow > chessBoard.GetUpperBound(0) || currentCol < 0 || currentCol > chessBoard.GetUpperBound(1)) return cost;
        if(chessBoard[currentRow, currentCol] > 0) return cost;

        cost = 1;
        for (k = 1; k < 9; k++)
        {
            if (KnightCanMove(chessBoard, currentRow, currentCol, k)) cost++;
        }

        return cost;
    }

    private static bool KnightCanMove(int[,] chessBoard, int currentRow, int currentCol, int direction)
    {
        //Can we move the knight to given direction/position?
        bool ret = false;

        MoveKnight(ref currentRow, ref currentCol, direction);

        if (currentRow >= 0 && currentRow <= chessBoard.GetUpperBound(0) && currentCol >= 0 && currentCol <= chessBoard.GetUpperBound(1))
        {
            if (chessBoard[currentRow, currentCol] == 0) ret = true;
        }

        return ret;
    }

    private static void MoveKnight(ref int currentRow, ref int currentCol, int direction)
    {

        const int UPLEFT = 4;       //1
        const int LEFTUP = 8;       //2
        const int RIGHTUP = 7;      //3
        const int UPRIGHT = 2;      //4
        const int DOWNRIGHT = 1;    //5
        const int RIGHTDOWN = 6;    //6
        const int LEFTDOWN = 5;     //7
        const int DOWNLEFT = 3;     //7

        switch (direction)
        {
            case UPLEFT:
                currentRow = currentRow - 1;
                currentCol = currentCol - 2;
                break;
            case LEFTUP:
                currentRow = currentRow - 2;
                currentCol = currentCol - 1;
                break;
            case RIGHTUP:
                currentRow = currentRow - 2;
                currentCol = currentCol + 1;
                break;
            case UPRIGHT:
                currentRow = currentRow - 1;
                currentCol = currentCol + 2;
                break;
            case DOWNRIGHT:
                currentRow = currentRow + 1;
                currentCol = currentCol + 2;
                break;
            case RIGHTDOWN:
                currentRow = currentRow + 2;
                currentCol = currentCol + 1;
                break;
            case LEFTDOWN:
                currentRow = currentRow + 2;
                currentCol = currentCol - 1;
                break;
            case DOWNLEFT:
                currentRow = currentRow + 1;
                currentCol = currentCol - 2;
                break;
            default:
                break;
        }

        return;
    }

    static void PrintTable(int[,] chessBoard)
    {
        int i, j;
        string s;

        for(i = 0; i < chessBoard.GetLength(0); i++)
        {
            s = "";
            for(j = 0; j < chessBoard.GetLength(1); j++)
            {
                s = s + chessBoard[i, j].ToString().PadLeft(4);
            }

            Console.WriteLine(s);
        }
        
    }

}



