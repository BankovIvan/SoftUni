using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int nNum;
        int[] arrResult1;

        nNum = int.Parse(Console.ReadLine());

        if (nNum > 0)
        {
            arrResult1 = new int[nNum];
        }
        else return;

        NestedLoopsToRecursion1(arrResult1, 0);


        return;

    }

    private static void NestedLoopsToRecursion1(int[] arrResult1, int idx)
    {
        int i;

        if(idx <= arrResult1.GetUpperBound(0))
        {

            for(i=0; i< arrResult1.Length; i++)
            {
                arrResult1[idx] = i + 1;
                NestedLoopsToRecursion1(arrResult1, idx + 1);
            }

        }
        else
        {
            Console.WriteLine(string.Join(" ", arrResult1));
        }

    }
}


