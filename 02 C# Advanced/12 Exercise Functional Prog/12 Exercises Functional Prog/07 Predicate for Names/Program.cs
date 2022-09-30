namespace _07_Predicate_for_Names
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            int nNameLength = int.Parse(Console.ReadLine());
            string sNamesList = Console.ReadLine();

            Func<string, Predicate<string>, List<string>> fCreateList = (x, y) =>
            {
                return new List<string>(
                    x.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Where(w => y(w))
                    .ToList());
                
            };

            Console.WriteLine(String.Join('\n', fCreateList(sNamesList, z => z.Length <= nNameLength)));

        }
    }
}