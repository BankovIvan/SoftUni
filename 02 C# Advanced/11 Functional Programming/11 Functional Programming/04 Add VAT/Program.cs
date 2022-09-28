namespace _04_Add_VAT
{

    using System;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                String.Join('\n', 
                    Console
                        .ReadLine()
                        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(double.Parse)
                        .Select(x => x * 1.2)
                        .Select(x => String.Format("{0:F2}", x))
                        .ToArray()
                ));
        }
    }
}