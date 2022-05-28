using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {

        int n;

        n = int.Parse(Console.ReadLine());

        PrintFigure(n);

        return;

    }

    private static void PrintFigure(int n)
    {
        if (n > 0)
        {
            Console.WriteLine(new string('*', n));
            PrintFigure(n - 1);
            Console.WriteLine(new string('#', n));

        }

    }

}