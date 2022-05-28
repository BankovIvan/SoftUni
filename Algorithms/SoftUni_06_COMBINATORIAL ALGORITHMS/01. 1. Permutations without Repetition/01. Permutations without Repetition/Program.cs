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
        if(index >= elements.Length)
        {
            Console.WriteLine(string.Join(" ", elements));
        }
        else
        {

            Gen(index + 1);

            //HashSet<string> used = new HashSet<string>(); 
            //used.Add(elements[index].ToString());

            for ( int i = index + 1; i < elements.Length; i++)
            {
                //if (!used.Contains(elements[i].ToString()))
                //if (elements[index + 1] == elements[i])
                //{

                    //used.Add(elements[i].ToString());

                    swap(index, i);
                    Gen(index + 1);
                    swap(index, i);
                //}

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

    private static void QuickPermutation(char[] a)
    {


        int i, j, N;
        int[] p;
        char c;

        //http://www.quickperm.org/

        //The Countdown QuickPerm Algorithm:

        //let a[] represent an arbitrary list of objects to permute
        //let N equal the length of a[]

        N = a.Length;

        //create an integer array p[] of size N + 1 to control the iteration
        //initialize p[0] to 0, p[1] to 1, p[2] to 2, ..., p[N] to N

        p = Enumerable.Range(0, N + 1).ToArray();


        //initialize index variable i to 1

        i = 1;

        //while (i < N) do
        while (i < N)
        {
            //decrement p[i] by 1
            p[i]--;

            //if i is odd, then let j = p[i] otherwise let j = 0


            if (i % 2 > 0) j = p[i];
            else j = 0;

            //swap(a[j], a[i])

            c = a[j];
            a[j] = a[i];
            a[i] = c;

            Console.WriteLine(string.Join(" ", a));

            //let i = 1

            i = 1;

            //while (p[i] is equal to 0) do

            while (p[i] == 0)
            {

                //let p[i] = i

                p[i] = i;

                //increment i by 1

                i++;

            } // end while (p[i] is equal to 0)
        } // end while (i < N)   


    }


    public static void Gen1(int index)
    {

    }

}
