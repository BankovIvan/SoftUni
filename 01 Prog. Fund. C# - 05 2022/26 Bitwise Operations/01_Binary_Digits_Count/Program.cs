namespace _01_Binary_Digits_Count
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    //using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {

            int number, value, mask = 1, count = 0;

            number = int.Parse(Console.ReadLine());
            value = int.Parse(Console.ReadLine());

            for(; number != 0; number = (number >> 1)){
                count += ((~ (number ^ value)) & mask);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(count);           
            Console.ResetColor();

        }
    }
}