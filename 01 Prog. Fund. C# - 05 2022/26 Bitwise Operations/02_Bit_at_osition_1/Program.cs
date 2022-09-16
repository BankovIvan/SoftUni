namespace _02_Bit_at_osition_1
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    //using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int nNumber, nPosition = 1;

            nNumber = int.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine((nNumber >> nPosition) & 1);           
            Console.ResetColor();

        }
    }
}