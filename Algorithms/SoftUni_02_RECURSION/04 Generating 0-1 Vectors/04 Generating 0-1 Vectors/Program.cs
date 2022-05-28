using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {

        int n;
        int[] vector;
        
        n = int.Parse(Console.ReadLine());

        if (n < 1) return;

        vector = new int[n];
        
        Gen01(vector, 0);

        return;

    }

    private static void Gen01(int[] vector, int index)
    {
        int i;

        if(index < vector.Length)
        {
            for(i = 0; i <= 1; i++)
            {
                vector[index] = i;
                Gen01(vector, index + 1);
            }  
            
        }
        else
        {
            //Console.WriteLine(string.Join(" ", vector));
            Console.WriteLine(string.Concat(vector));

        }

        return;
    }
}