namespace _02_Boss_Rush
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
            int i, nRepeat;
            string sInput, sBoss, sTitle;
            Regex rxBoss, rxTitle;
            Match matchBoss, matchTitle;

            nRepeat = int.Parse(Console.ReadLine());
            rxBoss = new Regex(@"\|(?<Boss>[A-Z]{4,})\|");
            rxTitle = new Regex(@"\|\:\#(?<Title>[a-zA-Z]{1,} [a-zA-Z]{1,})\#");

            for(i = 0; i < nRepeat; i++){
                sInput = Console.ReadLine();

                matchBoss = rxBoss.Match(sInput);
                if(! matchBoss.Success){
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Access denied!");           
                    Console.ResetColor();

                    continue;
                }

                matchTitle = rxTitle.Match(sInput);
                if(! matchTitle.Success){
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Access denied!");           
                    Console.ResetColor();

                    continue;
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("{0}, The {1}", 
                                        matchBoss.Groups["Boss"].Value, 
                                        matchTitle.Groups["Title"].Value); 
                Console.WriteLine(">> Strength: {0}", matchBoss.Groups["Boss"].Value.Length); 
                Console.WriteLine(">> Armor: {0}", matchTitle.Groups["Title"].Value.Length);          
                Console.ResetColor();

            }

        }
    }
}