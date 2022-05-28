using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int i, j, k;
        int rows, cols;
        char[,] matrix;

        List<MatrixArea> AreasList = new List<MatrixArea>();

        rows = int.Parse(Console.ReadLine());
        cols = int.Parse(Console.ReadLine());

        //if (rows < 1 || cols < 1) return;

        matrix = ReadMatrix(rows, cols);

        for(i = 0; i <= matrix.GetUpperBound(0); i++)
        {
            for (j = 0; j <= matrix.GetUpperBound(1); j++)
            {
                FindConnectedAreas(AreasList, matrix, i, j);
            }
        }

        AreasList.Sort();

        Console.WriteLine("Total areas found: {0}", AreasList.Count);

        k = 1;
        foreach (var Area in AreasList)
        {
            Area.id = k++;
            Area.PrintArea();
        }

        //PrintAreas(AreasList);

        return;

    }

    private static void FindConnectedAreas(List<MatrixArea> AreasList, char[,] matrix, int row, int col)
    {

        MatrixArea NextArea;

        if (IsInBound(matrix, row, col))
        {
            if (IsValid(matrix, row, col))
            {
                NextArea = new MatrixArea();
                NextArea.row = row;
                NextArea.col = col;
                FillArea(matrix, NextArea, row, col);

                AreasList.Add(NextArea);

            }

        }
    }

    private static void FillArea(char[,] matrix, MatrixArea Area, int row, int col)
    {
        

        if (IsInBound(matrix, row, col))
        {
            if (IsValid(matrix, row, col))
            {
                matrix[row, col] = 'V';
                Area.areaSize++;
                if (row < Area.row) Area.row = row;
                if (col < Area.row) Area.col = col;

                FillArea(matrix, Area, row + 1, col);
                FillArea(matrix, Area, row, col + 1);
                FillArea(matrix, Area, row - 1, col);
                FillArea(matrix, Area, row, col - 1);

            }

        }
    }

    private static bool IsInBound(char[,] matrix, int row, int col)
    {
        return row >= 0 &&
            row <= matrix.GetUpperBound(0) && 
            col >= 0 &&
            col <= matrix.GetUpperBound(1);
    }

    private static bool IsValid(char[,] matrix, int row, int col)
    {
        return matrix[row, col] == '-';
    }

    private static char[,] ReadMatrix(int rows, int cols)
    {
        int m, n;
        char[,] s2;
        char[] s1;

        s2 = new char[rows, cols];

        for (m = 0; m < rows; m++)
        {
            s1 = Console.ReadLine().ToUpper().ToCharArray();
            for (n = 0; n < cols; n++)
            {
                s2[m, n] = s1[n];
            }

        }

        return s2;
    }

    class MatrixArea : IComparable<MatrixArea>
    {
        public int id;
        public int row;
        public int col;
        public int areaSize;

        public MatrixArea()
        {
            id = 0;
            row = 0;
            col = 0;
            areaSize = 0;
        }

        public int CompareTo(MatrixArea other)
        {
            int c;

            c = other.areaSize.CompareTo(this.areaSize);

            if (c == 0)
            {
                c = row.CompareTo(other.row);
            }

            if (c == 0)
            {
                c = col.CompareTo(other.col);
            }

            return c;
        }

        public void PrintArea()
        {
            Console.WriteLine("Area #{0} at ({1}, {2}), size: {3}", id, row, col, areaSize);
        }

    }
}


