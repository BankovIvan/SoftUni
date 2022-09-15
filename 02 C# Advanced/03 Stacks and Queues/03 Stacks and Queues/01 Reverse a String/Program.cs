using System;
using System.Collections.Generic;

namespace _01_Reverse_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string sInput = Console.ReadLine();
            Stack<char> stackChars = new Stack<char>();

            foreach(var c in sInput)
            {
                stackChars.Push(c);
            }

            while(stackChars.Count > 0)
            {
                Console.Write(stackChars.Pop());
            }

            Console.WriteLine();

        }
    }
}
