using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{

    static char[] elements;
    //static bool[] used;
    HashSet<String> unique = new HashSet<String>();

    static int k;
    static char[] vector;

    static void Main(string[] args)
    {

        elements = Console.ReadLine().Split().Select(char.Parse).ToArray();
        //used = Enumerable.Repeat(false, elements.Length).ToArray();

        k = int.Parse(Console.ReadLine());
        vector = new char[k];

        Gen(0);
        //Console.WriteLine();
        //Gen2(0);

        return;

    }

    private static void Gen(int index)
    {

        int i;

        if (index >= k)
        {
            Console.WriteLine(string.Join(" ", vector));
        }
        else
        {

            //Gen(index + 1);

            for (i = 0; i < elements.Length; i++)
            {
                //if (!used[i])
                //{
                    vector[index] = elements[i];
                    //swap(index, i);
                    Gen(index + 1);
                    //swap(index, i);
                    //used[i] = false;
                //}

            }
        }
    }

    private static void Gen2(int index)
    {
        //No repetition for repeating values!
        // {A, B, B} -> {A, B, B}, {B, A, B}, {B, B, A}

        int i;

        if (index >= k)
        {
            Console.WriteLine(string.Join(" ", vector));
        }
        else
        {

            //Gen(index + 1);

            for (i = 0; i < elements.Length; i++)
            {
                //if (!used[i])
                //{
                vector[index] = elements[i];
                //swap(index, i);
                Gen(index + 1);
                //swap(index, i);
                //used[i] = false;
                //}

            }
        }
    }

}

class NchooseKHelper
{
    public void swap(char[] elements, int i, int j)
    {
        char c;
        c = elements[i];
        elements[i] = elements[j];
        elements[j] = c;
    }

}



