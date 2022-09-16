namespace _04_Bit_Destroyer
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    //using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int nNumber, nPosition;

            nNumber = int.Parse(Console.ReadLine());
            nPosition = int.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine((~ (1 << nPosition)) & nNumber);           
            Console.ResetColor();

        }
    }
}