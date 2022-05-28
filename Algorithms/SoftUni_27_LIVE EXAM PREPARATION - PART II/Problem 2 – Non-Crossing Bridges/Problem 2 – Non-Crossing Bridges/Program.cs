using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int i;
        int[] seq, prev;
        int total;
        string s;

        seq = Console.ReadLine().Split().Select(int.Parse).ToArray();
        prev = new int[seq.Length];

        total = FindConnections(seq, prev);

        if(total == 1)
        {
            Console.WriteLine("1 bridge found");
        }
        else if(total > 1)
        {
            Console.WriteLine("{0} bridges found", total);
        }
        else
        {
            Console.WriteLine("No bridges found");
        }

        i = 0;
        Console.Write((prev[i] >= 0 ? seq[i].ToString() : "X"));

        i = 1;
        while(i < prev.Length)
        {
            Console.Write(" " + (prev[i] >= 0 ? seq[i].ToString() : "X"));

            i++;
        }

        Console.WriteLine();

        return;
    }

    private static int FindConnections(int[] seq, /*int[] len,*/ int[] prev)
    {
        int lastIndex = 0;
        int i, x, total = 0;

        for (x = 0; x < seq.Length; x++)
        {
            prev[x] = -1;
            for (i = lastIndex; i < x; i++)
            {
                if ((seq[i] == seq[x]))
                {
                    prev[x] = i;
                    prev[i] = i;
                    lastIndex = x;

                    total++;

                    break;
                }
            }
        }

        return total;
    }

    private static void PrintMatrix(int[,] matrix)
    {
        int i, j;
        string s;

        for (i = 0; i < matrix.GetLength(0); i++)
        {
            s = matrix[i, 0].ToString().PadLeft(4);

            for (j = 1; j < matrix.GetLength(1); j++)
            {
                s = s + matrix[i, j].ToString().PadLeft(4);
            }
            Console.WriteLine(s);

        }
        Console.WriteLine();

        return;
    }

}