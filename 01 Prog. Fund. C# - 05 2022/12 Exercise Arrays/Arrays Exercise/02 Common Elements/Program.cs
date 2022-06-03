using System;

namespace _02_Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrString1, arrString2;

            arrString1 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            arrString2 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for(int i = 0; i < arrString2.Length; i++)
            {
                for(int j = 0; j < arrString1.Length; j++)
                {
                    if(arrString2[i] == arrString1[j])
                    {
                        Console.Write("{0} ", arrString2[i]);
                        break;
                    }
                }
            }

            Console.WriteLine();

        }
    }
}
