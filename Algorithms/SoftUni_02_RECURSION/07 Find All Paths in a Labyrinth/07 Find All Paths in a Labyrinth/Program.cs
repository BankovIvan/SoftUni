using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static List<char> path = new List<char>();
    static char[,] lab;

    static void Main(string[] args)
    {
        lab = ReadLab();
        //PrintLab();
        FindPaths(0, 0, 'S');

        return;

    }

    private static char[,] ReadLab()
    {
        int i, j, m, n;
        char[,] s2;
        char[] s1;
        
        i = int.Parse(Console.ReadLine());
        j = int.Parse(Console.ReadLine());

        s2 = new char[i, j];

        for(m = 0; m < i; m++)
        {
            s1 = Console.ReadLine().ToUpper().ToCharArray();
            for(n=0; n<j; n++)
            {
                s2[m, n] = s1[n];
            }
                
        }

        return s2;
        
    }

    private static void FindPaths(int row, int col, char direction)
    {
        if(!IsInBounds(row, col))return;

        path.Add(direction);
        //PrintLab();

        if(IsExit(row, col))
        {
            PrintPath();

        }
        else if(!IsVisited(row, col) && IsFree(row, col))
        {
            Mark(row, col);
            FindPaths(row, col + 1, 'R');
            FindPaths(row + 1, col, 'D');
            FindPaths(row, col - 1, 'L');
            FindPaths(row - 1, col, 'U');
            Unmark(row, col);

        }

        path.RemoveAt(path.Count-1);
    }

    private static void PrintLab()
    {
        int i, j;

        for(i=0; i <= lab.GetUpperBound(0); i++)
        {
            for(j=0; j <= lab.GetUpperBound(1); j++)
            {
                Console.Write(lab[i, j]);
            }
            Console.WriteLine();
        }

        Console.WriteLine(lab.ToString());
    }

    private static void Unmark(int row, int col)
    {
        lab[row, col] = '-';
        return;
    }

    private static void Mark(int row, int col)
    {
        lab[row, col] = 'V';
        return; 
    }

    private static bool IsFree(int row, int col)
    {
        return lab[row, col] == '-';
    }

    private static bool IsVisited(int row, int col)
    {
        return lab[row, col] == 'V';
    }

    private static void PrintPath()
    {
        int i;
        //path.
        //Console.WriteLine(path.ToString());

        for (i = 1; i < path.Count; i++) {
            Console.Write(path[i]);
        }

        Console.WriteLine();

    }

    private static bool IsExit(int row, int col)
    {
        return lab[row, col] == 'E';
    }

    private static bool IsInBounds(int row, int col)
    {
        return row >= 0 && row <= lab.GetUpperBound(0) && col >= 0 && col <= lab.GetUpperBound(1);
    }
}
