using System;
using System.Collections.Generic;

namespace _07_Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> qChildren = new Queue<string>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));
            int nPass = int.Parse(Console.ReadLine());
            int i;

            while(qChildren.Count > 1)
            {
                for (i = 1; i < nPass; i++)
                {
                    qChildren.Enqueue(qChildren.Dequeue());
                }
                Console.WriteLine("Removed {0}", qChildren.Dequeue());

            }

            Console.WriteLine("Last is {0}", qChildren.Dequeue());


        }
    }
}
