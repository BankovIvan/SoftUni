using System;
using System.Collections.Generic;

namespace _05_Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nInput = Array.ConvertAll(
                        Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                        new Converter<string, int>(int.Parse)
                        );
            int nValue;

            Queue<int> qNumbers = new Queue<int>();
            List<int> lstNumbers = new List<int>();

            foreach(var n in nInput)
            {
                qNumbers.Enqueue(n);
            }

            while(qNumbers.Count > 0)
            {
                nValue = qNumbers.Dequeue();
                if((nValue & 1) == 0)
                {
                    lstNumbers.Add(nValue);
                }
                
            }

            Console.WriteLine(string.Join(", ", lstNumbers));

        }
    }
}
