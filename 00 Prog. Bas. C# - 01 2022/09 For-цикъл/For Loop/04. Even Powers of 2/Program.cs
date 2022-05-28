using System;

namespace _04._Even_Powers_of_2
{
    class Program
    {
        static void Main(string[] args)
        {

            int i, j, n;

            n = int.Parse(Console.ReadLine());


            for(i = 0, j = 1; i <= n; i += 2)
            {
                Console.WriteLine(j);
                j = j * 2 * 2;
            }


        }
    }
}
