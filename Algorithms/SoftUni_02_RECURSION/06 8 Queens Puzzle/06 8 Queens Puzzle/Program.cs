using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {

        EightQueens Q = new EightQueens();

        Q.PutQueens(0);
        
        return;

    }

}

class EightQueens
{
    const int Size = 8;
    static bool[,] chessboard = new bool[Size, Size];

    private static HashSet<int> attackedRows = new HashSet<int>();
    private static HashSet<int> attackedColumns = new HashSet<int>();
    private static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
    private static HashSet<int> attackedRightDiagonals = new HashSet<int>();

    public int solutionsFound;

    public EightQueens()
    {
        solutionsFound = 0;
    }



    public void PutQueens(int row1)
    {
        int col1;

        if (row1 < Size)
        {
            for(col1=0; col1<Size; col1++)
            {
                if(CanPlaceQueen(row1, col1))
                {
                    MarkAllAttackedPositions(row1, col1);
                    //PrintSolution();
                    //Console.ReadLine();
                    PutQueens(row1 + 1);
                    UnmarkAllAttackedPositions(row1, col1);
                }
            }
        }
        else
        {
            //Console.WriteLine("Solution Found:");
            PrintSolution();
            //Console.ReadLine();
            solutionsFound++;

        }
    }

    private static bool CanPlaceQueen(int row, int col)
    {
        bool bResult;

        bResult = attackedRows.Contains(row) || 
            attackedColumns.Contains(col) || 
            attackedLeftDiagonals.Contains(row + col) ||
            attackedRightDiagonals.Contains(row - col);

        return !bResult;
    }

    private static void MarkAllAttackedPositions(int row, int col)
    {
        attackedRows.Add(row);
        attackedColumns.Add(col);
        attackedLeftDiagonals.Add(row + col);
        attackedRightDiagonals.Add(row - col);
        chessboard[row, col] = true;

        return;

    }

    private static void UnmarkAllAttackedPositions(int row, int col)
    {
        attackedRows.Remove(row);
        attackedColumns.Remove(col);
        attackedLeftDiagonals.Remove(row + col);
        attackedRightDiagonals.Remove(row - col);
        chessboard[row, col] = false;

        return;

    }

    private static void PrintSolution()
    {
        int i, j;
        
        for(i=0; i<Size; i++)
        {
//            for(j=0; j<Size; j++)
//            {
//                if (chessboard[i,j] == true)
//                {
//                    Console.Write("*");
//                }
//                else
//                {
//                    Console.Write("_");
//                }
//                Console.Write(" ");
//
//            }

            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", 
                (chessboard[i, 0] ? "*" : "-"),
                (chessboard[i, 1] ? "*" : "-"),
                (chessboard[i, 2] ? "*" : "-"),
                (chessboard[i, 3] ? "*" : "-"),
                (chessboard[i, 4] ? "*" : "-"),
                (chessboard[i, 5] ? "*" : "-"),
                (chessboard[i, 6] ? "*" : "-"),
                (chessboard[i, 7] ? "*" : "-"));
        }

        Console.WriteLine();

    }
}