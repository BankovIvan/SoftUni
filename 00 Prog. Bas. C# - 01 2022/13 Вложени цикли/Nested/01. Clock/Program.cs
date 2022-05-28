using System;

namespace _01._Clock
{
    class Program
    {
        static void Main(string[] args)
        {

            int i=0, j=0;

            for(i = 0; i < 24; i++)
            {
                for(j = 0; j < 60; j++)
                {
                    Console.WriteLine("{0}:{1}", i, j);
                }
            }

        }
    }
}
