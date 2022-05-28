using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{

    static char[] elements;

    static long counter = 0;

    static HashSet<string> Results = new HashSet<string>();

    static void Main(string[] args)
    {

        elements = Console.ReadLine().Split().Select(char.Parse).ToArray();

        Gen(0);

        Console.WriteLine(counter++);


        return;

    }

    private static void Gen(int index)
    {
        if (index >= elements.Length)
        {
            if (RotateAndAdd2()) counter++;
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

    private static bool RotateAndAdd2()
    {
        int i, j, k;

        if (Results.Contains(string.Concat(elements)))
        {
            return false;
        }
        
        for (i = 0; i < 4; i++)
        {
            RotateX();

            for (j = 0; j < 4; j++)
            {
                RotateY();

                for (k = 0; k < 4; k++)
                {
                    RotateZ();
                    Results.Add(string.Concat(elements));
                }
            }
        }
        
        return true;
    }

    private static void RotateX()
    {
        char c;

        c = elements[11];
        elements[11] = elements[7];
        elements[7] = elements[10];
        elements[10] = elements[3];
        elements[3] = c;

        c = elements[8];
        elements[8] = elements[5];
        elements[5] = elements[9];
        elements[9] = elements[1];
        elements[1] = c;

        c = elements[4];
        elements[4] = elements[6];
        elements[6] = elements[2];
        elements[2] = elements[0];
        elements[0] = c;

    }


    private static void RotateY()
    {
        char c;

        c = elements[0];
        elements[0] = elements[3];
        elements[3] = elements[2];
        elements[2] = elements[1];
        elements[1] = c;

        c = elements[4];
        elements[4] = elements[7];
        elements[7] = elements[6];
        elements[6] = elements[5];
        elements[5] = c;

        c = elements[11];
        elements[11] = elements[10];
        elements[10] = elements[9];
        elements[9] = elements[8];
        elements[8] = c;

    }

    private static void RotateZ()
    {
        char c;

        c = elements[0];
        elements[0] = elements[11];
        elements[11] = elements[4];
        elements[4] = elements[8];
        elements[8] = c;

        c = elements[2];
        elements[2] = elements[10];
        elements[10] = elements[6];
        elements[6] = elements[9];
        elements[9] = c;

        c = elements[5];
        elements[5] = elements[1];
        elements[1] = elements[3];
        elements[3] = elements[7];
        elements[7] = c;

    }

}


