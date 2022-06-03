using System;

namespace _04_Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrQueue;
            int i, nLast, nRotations;
            string sSwapVar;

            arrQueue = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            nRotations = int.Parse(Console.ReadLine());

            nLast = arrQueue.Length - 1;

            for (; nRotations > 0; nRotations--)
            {
                sSwapVar = arrQueue[0];
                for(i = 0; i < nLast; i++)
                {
                    arrQueue[i] = arrQueue[i + 1];
                }
                arrQueue[i] = sSwapVar;
            }

            Console.WriteLine(string.Join(' ', arrQueue));

        }
    }
}
