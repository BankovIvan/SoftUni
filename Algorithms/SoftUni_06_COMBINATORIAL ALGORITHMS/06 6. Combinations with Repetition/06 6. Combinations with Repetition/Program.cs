using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{

    static char[] elements;
    //static bool[] used;

    static int k;
    static char[] vector;

    //static HashSet<Char[]> unique;

    static void Main(string[] args)
    {

        elements = Console.ReadLine().Split().Select(char.Parse).ToArray();
        //used = Enumerable.Repeat(false, elements.Length).ToArray();

        k = int.Parse(Console.ReadLine());
        vector = new char[k];

        //unique = new HashSet<Char[]>();

        Gen(0, 0);

        return;

    }

    private static void Gen(int index, int start)
    {

        int i;

        if (index >= k)
        {
            Console.WriteLine(string.Join(" ", vector));
        }
        else
        {

            //Gen(index + 1);

            for (i = start; i < elements.Length; i++)
            {
                //if (!used[i])
                //{
                vector[index] = elements[i];
                //NchooseK_Helper.swap(elements, index, i);
                Gen(index + 1, i);
                //NchooseK_Helper.swap(elements, index, i);
                //used[i] = false;
                //}

            }
        }
    }

}

class NchooseK_Helper
{
    public static void swap(char[] elements, int i, int j)
    {
        char c;
        c = elements[i];
        elements[i] = elements[j];
        elements[j] = c;
    }

}



