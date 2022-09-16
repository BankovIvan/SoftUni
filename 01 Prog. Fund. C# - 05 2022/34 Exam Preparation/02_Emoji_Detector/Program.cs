namespace _02_Emoji_Detector
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    //using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            string sInput;
            long nCoolness = 1;
            Regex rx;
            MatchCollection colMatches;

            sInput = Console.ReadLine();

            rx = new Regex(@"\d");
            colMatches = rx.Matches(sInput);
            foreach(Match m in colMatches){
                nCoolness *= int.Parse(m.Value);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Cool threshold: {0}", nCoolness);           
            Console.ResetColor();

            rx = new Regex(@"(\*{2}|\:{2})(?<data>[A-Z][a-z]{2,})(\1)");
            colMatches = rx.Matches(sInput);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0} emojis found in the text. The cool ones are:", colMatches.Count);           
            Console.ResetColor();

            foreach(Match m in colMatches){
                long nSum = 0;

                foreach(char c in m.Groups["data"].Value){
                    nSum += (long)c;
                }

                if(nSum > nCoolness){
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(m.Value);           
                    Console.ResetColor();
                }

            }

        }
    }
}
