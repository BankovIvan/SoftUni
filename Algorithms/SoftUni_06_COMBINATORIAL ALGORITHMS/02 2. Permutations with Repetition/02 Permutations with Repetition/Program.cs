using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{

    static char[] elements;


    static void Main(string[] args)
    {

        elements = Console.ReadLine().Split().Select(char.Parse).ToArray();

        //Console.WriteLine(string.Join(" ", InputData));

        //Console.WriteLine(string.Join(" ", elements));
        //QuickPermutation1(elements);

        Gen(0);

        return;

    }

    private static void Gen(int index)
    {
        if (index >= elements.Length)
        {
            Console.WriteLine(string.Join(" ", elements));
        }
        else
        {

            Gen(index + 1);

            HashSet<string> used = new HashSet<string>();
            used.Add(elements[index].ToString());

            for (int i = index + 1; i < elements.Length; i++)
            {
                if (!used.Contains(elements[i].ToString()))
                {

                    used.Add(elements[i].ToString());

                    swap(index, i);
                    Gen(index + 1);
                    swap(index, i);
                }

            }
        }
    }

    private static void swap(int i, int j)
    {
        char c;
        c = elements[i];
        elements[i] = elements[j];
        elements[j] = c;
    }


}
