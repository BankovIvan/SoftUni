namespace _06_Tri_bit_Switch
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    //using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int nNumber, nPosition, nMask = 7, nFlip = 0;

            nNumber = int.Parse(Console.ReadLine());
            nPosition = int.Parse(Console.ReadLine());

            nMask = nMask << nPosition;
            
            nFlip = nNumber & nMask;
            nFlip = ~ nFlip;
            nFlip = nFlip & nMask;

            nMask = ~ nMask;
            nNumber = nNumber & nMask;

            nNumber = nNumber | nFlip;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(nNumber);           
            Console.ResetColor();

        }
    }
}
