using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {

        int i, j, rows, cols;
        int[,] matrix, memo;
        int[] input;

        rows = int.Parse(Console.ReadLine());
        cols = int.Parse(Console.ReadLine());

        matrix = new int[rows, cols];
        memo = new int[rows, cols];
        input = new int[cols];

        for (i = 0; i < rows; i++)
        {
            Console.Write(" ");
            input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            for (j = 0; j < cols; j++)
            {
                matrix[i, j] = input[j];
                memo[i, j] = int.MaxValue;
            }

        }

        memo[0, 0] = matrix[0, 0];

        //Console.WriteLine();
        //PrintMatrix(matrix);
        //Console.WriteLine();
        //PrintMatrix(memo);

        //Console.WriteLine();
        ShortestPath(matrix, memo, 0, 0);
        Console.WriteLine("Length: {0}", memo[rows - 1, cols - 1]);

        //Console.WriteLine();
        //PrintMatrix(memo);

        Console.WriteLine("Path: " + PrinthPath(matrix, memo));

        return;
    }

    private static void ShortestPath(int[,] matrix, int[,] memo, int row, int col)
    {
        int nextRow, nextCol, cost, nRows, nCols;

        //Console.WriteLine();
        //PrintMatrix(memo);

        nRows = matrix.GetLength(0);
        nCols = matrix.GetLength(1);
        cost = 0;

        //Up
        nextRow = row - 1;
        nextCol = col;
        if (nextRow >= 0 && nextRow < nRows && nextCol >= 0 && nextCol < nCols)
        {
            cost = memo[row, col] + matrix[nextRow, nextCol];
            if (memo[nextRow, nextCol] > cost)
            {
                memo[nextRow, nextCol] = cost;
                ShortestPath(matrix, memo, nextRow, nextCol);
            }
        }

        //Left
        nextRow = row;
        nextCol = col - 1;
        if (nextRow >= 0 && nextRow < nRows && nextCol >= 0 && nextCol < nCols)
        {
            cost = memo[row, col] + matrix[nextRow, nextCol];
            if (memo[nextRow, nextCol] > cost)
            {
                memo[nextRow, nextCol] = cost;
                ShortestPath(matrix, memo, nextRow, nextCol);
            }
        }

        //Down
        nextRow = row + 1;
        nextCol = col;
        if (nextRow >= 0 && nextRow < nRows && nextCol >= 0 && nextCol < nCols)
        {
            cost = memo[row, col] + matrix[nextRow, nextCol];
            if (memo[nextRow, nextCol] > cost)
            {
                memo[nextRow, nextCol] = cost;
                ShortestPath(matrix, memo, nextRow, nextCol);
            }
        }

        //Right
        nextRow = row;
        nextCol = col + 1;
        if (nextRow >= 0 && nextRow < nRows && nextCol >= 0 && nextCol < nCols)
        {
            cost = memo[row, col] + matrix[nextRow, nextCol];
            if (memo[nextRow, nextCol] > cost)
            {
                memo[nextRow, nextCol] = cost;
                ShortestPath(matrix, memo, nextRow, nextCol);
            }
        }


        return;

    }

    private static string PrinthPath(int[,] matrix, int[,] memo)
    {
        int i, j, prevRow, prevCol, nextRow, nextCol, cost;
        int nRows = matrix.GetLength(0);
        int nCols = matrix.GetLength(1);
        string s = "";

        i = nRows - 1;
        j = nCols - 1;
        nextRow = 0;
        nextCol = 0;

        cost = memo[i, j];
        s = matrix[i, j].ToString();

        while (i > 0 || j > 0)
        {

            //Left
            prevRow = i;
            prevCol = j - 1;
            if (prevRow >= 0 && prevRow < nRows && prevCol >= 0 && prevCol < nCols)
            {
                if (memo[prevRow, prevCol] <= cost)
                {
                    cost = memo[prevRow, prevCol];
                    nextRow = prevRow;
                    nextCol = prevCol;
                }
            }

            //Up
            prevRow = i - 1;
            prevCol = j;
            if (prevRow >= 0 && prevRow < nRows && prevCol >= 0 && prevCol < nCols)
            {
                if (memo[prevRow, prevCol] <= cost)
                {
                    cost = memo[prevRow, prevCol];
                    nextRow = prevRow;
                    nextCol = prevCol;
                }
            }

            //Right
            prevRow = i;
            prevCol = j + 1;
            if (prevRow >= 0 && prevRow < nRows && prevCol >= 0 && prevCol < nCols)
            {
                if (memo[prevRow, prevCol] <= cost)
                {
                    cost = memo[prevRow, prevCol];
                    nextRow = prevRow;
                    nextCol = prevCol;
                }
            }

            //Down
            prevRow = i + 1;
            prevCol = j;
            if (prevRow >= 0 && prevRow < nRows && prevCol >= 0 && prevCol < nCols)
            {
                if (memo[prevRow, prevCol] <= cost)
                {
                    cost = memo[prevRow, prevCol];
                    nextRow = prevRow;
                    nextCol = prevCol;
                }
            }

            i = nextRow;
            j = nextCol;

            s = matrix[i, j].ToString() + " " + s;

        }

        return s;

    }

    private static void PrintMatrix(int[,] matrix)
    {
        int i, j;
        string s;

        for (i = 0; i < matrix.GetLength(0); i++)
        {
            s = matrix[i, 0].ToString().PadLeft(3);

            for (j = 1; j < matrix.GetLength(1); j++)
            {
                s = s + " " + matrix[i, j].ToString().PadLeft(3);

            }

            Console.WriteLine(s);

        }

        return;

    }
}

