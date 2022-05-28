using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    public static char[] vector;
    public static char[] result;

    static void Main(string[] args)
    {
        int i = 0;

        ReadData();

        PermuteVector(0, 0, false);

        return;
    }

    private static void PermuteVector(int indexVector, int indexResult, bool mark)
    {

        if(indexVector >= vector.Length)
        {
            if(indexResult >= result.Length)
            {
                Console.WriteLine(new string(result));
            }
            
            return;
        }

        if (mark == true)
        {
            result[indexResult] = '|';
            PermuteVector(indexVector, indexResult + 1, false);
            result[indexResult] = '*';
        }

        if (vector[indexVector] == '1')
        {
            result[indexResult] = '1';
            PermuteVector(indexVector + 1, indexResult + 1, true);
            result[indexResult] = '*';
        }
        else
        {
            result[indexResult] = '0';
            PermuteVector(indexVector + 1, indexResult + 1, mark);
            result[indexResult] = '*';
        }

        return;

    }

    private static int ReadData()
    {
        int i, count = 0;
        string[] s;

        Console.Write("");
        s = Console.ReadLine().Split(' ');

        vector = new char[s.Length];

        for(i = 0; i < s.Length; i++)
        {
            vector[i] = s[i].ToCharArray()[0];
            if(vector[i] == '1')
            {
                count++;
            }
        }

        result = new char[s.Length + count - 1];

        return count;
    }
}