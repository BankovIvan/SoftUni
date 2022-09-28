namespace _03_Count_Uppercase_Words
{
    using System;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> MyUpperCase = x => char.IsUpper(x[0]);

            Console.WriteLine(string.Join('\n', 
                                Console
                                    .ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Where(w => MyUpperCase(w))
                                    .ToArray()));


        }
    }
}