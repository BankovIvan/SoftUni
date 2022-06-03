using System;

namespace _04_Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrStrings = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            for(int i = arrStrings.Length-1; i >= 0; i--)
            {
                Console.Write(arrStrings[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
