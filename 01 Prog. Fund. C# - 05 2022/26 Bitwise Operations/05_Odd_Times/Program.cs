namespace _05_Odd_Times
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    //using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {

            int[] arrNumbers;
            int nResult = 0;

            arrNumbers = Array.ConvertAll(
                            Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                            new Converter<string, int>(int.Parse)
                            );

            foreach(var v in arrNumbers){
                nResult = (nResult ^ v);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(nResult);           
            Console.ResetColor();

        }
    }
}