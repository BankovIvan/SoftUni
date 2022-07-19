using System;

namespace _02_Repeat_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrInput;
            int i;

            arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach(var v in arrInput)
            {
                for(i = 0; i < v.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(v);
                    Console.ResetColor();
                }
            }

        }
    }
}
