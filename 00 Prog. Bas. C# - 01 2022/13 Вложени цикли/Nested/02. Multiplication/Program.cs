using System;

namespace _02._Multiplication
{
    class Program
    {
        static void Main(string[] args)
        {

            int i = 0, j = 0;

            for(i = 1; i <= 10; i++)
            {
                for(j = 1; j <= 10; j++)
                {
                    Console.WriteLine("{0} * {1} = {2}", i, j, i * j);
                }
            }

        }
    }
}
