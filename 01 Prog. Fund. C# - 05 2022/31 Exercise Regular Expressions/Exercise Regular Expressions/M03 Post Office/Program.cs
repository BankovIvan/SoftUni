using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace M03_Post_Office
{
    class Program
    {
        static void Main(string[] args)
        {
            string sPattern1 = @"(?<Part1>(?<Symbol>\#|\$|\%|\*|\&)(?<Letter1>[A-Z]+)(?:\k<Symbol>))";
            string sPattern2 = @"(?<Part2>(?<Letter2>(?<![\d])\d\d):(?<Length2>\d\d(?!\d)))";
            //string sPattern2 = @"(?<Part2>(?<Letter2>[0-9][0-9]):(?<Length2>[0-9][0-9]))";
            string sPattern3 = @"(?:^|\s)(?<Part3>[A-Z][\S]*)";

            MatchCollection colMatches;
            string[] sInput;
            HashSet<char> dicChars = new HashSet<char>();
            Dictionary<char, int> dicNames = new Dictionary<char, int>();

            //////////////////////////////////////////////////////////////////////////////////
            // HAHAHAHAHAHAHAHAHHAHAHAHAHHAHAHHAHAHAHHAH
            //////////////////////////////////////////////////////////////////////////////////
            
            List<char> lstPrintOrdet = new List<char>();
            Dictionary<char, string> dicPrintOrder = new Dictionary<char, string>();
            
            // &$@#^%$EQWTERQREQREQRETRQT@&@^&$&^@^*^@$!^%!~#@^*$%
            // $#@#$#$$@#%^^%UTGUIU()I)_KOPJUYTR%^$$%###@@%$^&*(&U
            // !#@!~#@~@#!$#@#^%^*%*&(&()(_+()*&(*&^%$%$#^$WE%RDF^

            sInput = Console.ReadLine().Split('|');

            //PART 1 - First Letters
            colMatches = Regex.Matches(sInput[0], sPattern1);

            foreach (Match m1 in colMatches)
            {
            //Match m1 = colMatches[0];
                if (m1.Groups["Letter1"].Success)
                {
                    foreach (char c in m1.Groups["Letter1"].Value)
                    {
                        if (!dicChars.Contains(c))
                        {
                            dicChars.Add(c);
                            lstPrintOrdet.Add(c);
                        }
                    }
                }
            }
            
            //PART 2 - Length
            colMatches = Regex.Matches(sInput[1], sPattern2);
            foreach (Match m in colMatches)
            {
                if (m.Groups["Part2"].Success)
                {
                    char c = (char)int.Parse(m.Groups["Letter2"].Value);
                    if (dicChars.Contains(c))
                    {
                        if (!dicNames.ContainsKey(c))
                        {
                            int nLength = int.Parse(m.Groups["Length2"].Value);
                            if(nLength > 0 && nLength < 20)
                            {
                                dicNames.Add(c, nLength + 1);
                            }
                            
                        }
                    }
                }
            }

            //PART 3 - Length
            colMatches = Regex.Matches(sInput[2], sPattern3);
            foreach (Match m in colMatches)
            {
                if (m.Groups["Part3"].Success)
                {
                    if (dicNames.ContainsKey(m.Groups["Part3"].Value[0]))
                    {
                        if(dicNames[m.Groups["Part3"].Value[0]] == m.Groups["Part3"].Value.Length)
                        {
                            dicPrintOrder.Add(m.Groups["Part3"].Value[0], m.Groups["Part3"].Value);

                            //Console.ForegroundColor = ConsoleColor.Yellow;
                            //Console.WriteLine(m.Groups["Part3"].Value);
                            //Console.ResetColor();
                        }
                    }
                }
            }

            // PRINT
            foreach(char c in lstPrintOrdet)
            {
                if (dicPrintOrder.ContainsKey(c))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(dicPrintOrder[c]);
                    Console.ResetColor();
                }
            }

        }
    }
}
