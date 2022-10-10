namespace _05_Generic_Count_Method_Strings
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            int nRepeat = int.Parse(Console.ReadLine());
            List<string> lstElements = new List<string>();

            for(int i = 0; i < nRepeat; i++)
            {
                lstElements.Add(Console.ReadLine());
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(GenericCount.Compare(lstElements, Console.ReadLine()));
            Console.ResetColor();

        }
    }
}
