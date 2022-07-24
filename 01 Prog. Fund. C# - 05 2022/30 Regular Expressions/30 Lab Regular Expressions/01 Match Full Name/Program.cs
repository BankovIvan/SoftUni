using System;
using System.Text.RegularExpressions;

namespace _01_Match_Full_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            string sInput = Console.ReadLine();
            string sPattern = @"\b([A-Z][a-z]+) {1}([A-Z][a-z]+)\b";

            Regex regFullName = new Regex(sPattern);
            MatchCollection colMatches = regFullName.Matches(sInput);

            foreach(Match m in colMatches)
            {
                Console.Write(m.Value + " ");
            }


        }
    }
}
