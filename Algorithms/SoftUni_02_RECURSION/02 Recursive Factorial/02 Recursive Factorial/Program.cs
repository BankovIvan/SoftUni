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

        Console.WriteLine(factorial(n));

        return;
    }

    static long factorial(int n)
    {
        if (n > 0)
        {
            return n * factorial(n - 1);
        }
        else
        {
            return 1;
        }

    }
}


