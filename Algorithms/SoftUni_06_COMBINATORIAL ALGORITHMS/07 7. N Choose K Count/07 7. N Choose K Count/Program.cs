using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {

        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        Console.WriteLine(PascalTriange(n, k));

        return;
    }

    private static int PascalTriange(int n, int k)
    {

        if (k > n) return 0;
        else if (k == n || k == 0) return 1;
        else return PascalTriange(n - 1, k - 1) + PascalTriange(n - 1, k);

    }
}
