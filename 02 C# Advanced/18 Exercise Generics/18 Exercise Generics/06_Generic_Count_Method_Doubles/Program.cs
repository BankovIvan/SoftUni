namespace _06_Generic_Count_Method_Doubles
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            int nRepeat = int.Parse(Console.ReadLine());
            List<double> lstElements = new List<double>();

            for (int i = 0; i < nRepeat; i++)
            {
                lstElements.Add(double.Parse(Console.ReadLine()));
            }

            double element = double.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(GenericCount.Compare<double>(lstElements, element));
            Console.ResetColor();

        }
    }
}
