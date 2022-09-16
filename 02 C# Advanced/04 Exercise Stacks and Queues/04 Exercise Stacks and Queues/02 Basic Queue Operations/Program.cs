using System;
using System.Collections.Generic;

namespace _02_Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, nMin = int.MaxValue, nNext, nN, nS, nX;

            int[] arrInput = Array.ConvertAll(
                        Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                        new Converter<string, int>(int.Parse)
                        );

            nN = arrInput[0];
            nS = arrInput[1];
            nX = arrInput[2];

            arrInput = Array.ConvertAll(
                        Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                        new Converter<string, int>(int.Parse)
                        );

            Queue<int> qNumbers = new Queue<int>();

            for (i = 0; i < nN && i < arrInput.Length; i++)
            {
                qNumbers.Enqueue(arrInput[i]);
            }

            for(i = 0; i < nS && qNumbers.Count > 0; i++)
            {
                qNumbers.Dequeue();
            }

            if(qNumbers.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            while(qNumbers.Count > 0)
            {
                nNext = qNumbers.Dequeue();
                if(nNext == nX)
                {
                    Console.WriteLine("true");
                    return;
                }
                else if(nMin > nNext)
                {
                    nMin = nNext;
                }

            }

            Console.WriteLine(nMin);

        }
    }
}
