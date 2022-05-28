using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int N, openBrackets /* ( */, closeBrackets /* ) */;
        char[] vector;

        LinkedList<string> output = new LinkedList<string>();

        //Console.Write("    ");
        N = int.Parse(Console.ReadLine());

        vector = new char[N * 2];
        openBrackets = N;
        closeBrackets = N;

        PermuteBrackets(vector, output, openBrackets, closeBrackets);
        //brackets(N, 0, 0, vector, output);

        foreach (var item in output)
        {
            Console.WriteLine(item);
        }

        return;
    }

    private static void PermuteBrackets(char[] vector, LinkedList<string> output, int openBrackets, int closeBrackets)
    {
        int index;

        if(closeBrackets < openBrackets)
        {
            return;
        }

        index = vector.Length - (openBrackets + closeBrackets);

        if (index >= vector.Length)
        {
            output.AddLast(new string(vector));
            return;
        }


        if (openBrackets > 0)
        {
            vector[index] = '(';
            PermuteBrackets(vector, output, openBrackets - 1, closeBrackets);
            //vector[index] = '-';
        }

        if(closeBrackets > 0)
        {
            vector[index] = ')';
            PermuteBrackets(vector, output, openBrackets, closeBrackets - 1);
            //vector[index] = '-';
        }

        return;

    }

    static void brackets(int openStock, int closeStock, int index, char[] arr, LinkedList<string> output)
    {
        //https://stackoverflow.com/questions/3172179/valid-permutation-of-parenthesis
        //
        while (closeStock >= 0)
        {
            if (openStock > 0)
            {
                arr[index] = '(';
                brackets(openStock - 1, closeStock + 1, index + 1, arr, output);
            }
            if (closeStock-- > 0)
            {
                arr[index++] = ')';
                if (index == arr.Length)
                {
                    output.AddLast(new string(arr));
                }
            }
        }
    }

}
