using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

class Program
{

    static void Main(string[] args)
    {
        string[] s;
        int i, j;
        BigInteger total = 0, TEST = 13;
        BigInteger[] numbers = new BigInteger[3];

        Console.Write("    ");
        s = Console.ReadLine().Split(' ');

        for (i = 0; i < 3; i++)
        {
            numbers[i] = BigInteger.Parse(s[i]);
        }

        for (i = 0; i < 8; i++)
        {
            total = 0;

            for(j = 0; j < 3; j++)
            {
                if((i & (1 << j)) > 0)
                {
                    total = total - numbers[j];
                }
                else
                {
                    total = total + numbers[j];
                }
            }
            
            if(total == TEST)
            {
                Console.WriteLine("Yes");
                return;
            }
        }


        Console.WriteLine("No");

        return;

    }

}
