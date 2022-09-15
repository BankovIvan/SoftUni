using System;
using System.Collections.Generic;

namespace _01_Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, nN, nS, nX, nNumber = 0, nSmallest = int.MaxValue;
            int[] arrInput;
            Stack<int> stcNumbers = new Stack<int>();

            arrInput = Array.ConvertAll(
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

            for(i = 0; i < nN; i++)
            {
                stcNumbers.Push(arrInput[i]);
            }

            for (i = 0; i < nS; i++)
            {
                stcNumbers.Pop();
            }

            if(stcNumbers.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            while (stcNumbers.Count > 0)
            {
                nNumber = stcNumbers.Pop();

                if(nNumber == nX)
                {
                    Console.WriteLine("true");
                    return;
                }

                if(nSmallest > nNumber)
                {
                    nSmallest = nNumber;
                }
            }

            Console.WriteLine(nSmallest);

        }
    }
}
