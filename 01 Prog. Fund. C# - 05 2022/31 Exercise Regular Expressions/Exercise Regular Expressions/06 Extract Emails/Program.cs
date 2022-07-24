using System;
using System.Text.RegularExpressions;

namespace _06_Extract_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string sPattern = @"(^|(?<=\s))(([A-Za-z0-9]+[._-]{1})*[A-Za-z0-9]+@([A-Za-z]+[._-]{1})*[A-Za-z]+\.[A-Za-z]+)";
            MatchCollection colMatches;

            string sInput = Console.ReadLine();
            colMatches = Regex.Matches(sInput, sPattern);
            foreach(Match m in colMatches)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(m.Value);
                Console.ResetColor();
            }

        }
    }
}
