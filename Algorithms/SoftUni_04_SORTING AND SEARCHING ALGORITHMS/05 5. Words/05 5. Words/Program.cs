using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Program
{

    static int count = 0;
    static char[] symbols;


    static void Main(string[] args)
    {
        HashSet<char> check;
        int i;

        symbols = Console.ReadLine().ToCharArray();

        check = new HashSet<char>(symbols);

        if (check.Count == symbols.Length)
        {
            for (i = 1, count = 1; i <= symbols.Length; i++) count = count * i;
        }
        else
        {
            GeneratePermutations(0);
        }


        Console.WriteLine(count);

        return;

    }

    private static void GeneratePermutations(int index)
    {
        int i;
        //int counter;
        HashSet<char> swapped;
        char cur;
        bool isvalid;

        //counter = 0;
        isvalid = true;

        if (index >= symbols.GetUpperBound(0))
        {

            for(i = 0; i < symbols.Length - 1; i++)
            {
                if(symbols[i] == symbols[i + 1])
                {
                    isvalid = false;
                    break;
                }
            }

            if (isvalid) count++;
            return;
        }




        swapped = new HashSet<char>();

        for(i = index; i < symbols.Length; i++)
        {
            if (!swapped.Contains(symbols[i]))
            {
                cur = symbols[index];
                symbols[index] = symbols[i];
                symbols[i] = cur;

                GeneratePermutations(index + 1);

                swapped.Add(symbols[index]);
                symbols[i] = symbols[index];
                symbols[index] = cur;
            }
        }


    }
}