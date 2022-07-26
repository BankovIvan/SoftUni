using System;
using System.Text.RegularExpressions;

namespace M01_Winning_Ticket
{
    class Program
    {
        static void Main(string[] args)
        {
            //string sPattern = @"[\@\#\$\^]{6,}";   ---> NOT WORKING !!!???
            string sPattern = @"(\@{6,}|\${6,}|\^{6,}|\#{6,})";
            //MatchCollection colMatches;
            Match matchLeft, matchRight;
            string[] arrInput;
            int nLength;

            arrInput = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach(string s in arrInput)
            {

                if(s.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                matchLeft = Regex.Match(s.Substring(0, 10), sPattern);
                matchRight = Regex.Match(s.Substring(10, 10), sPattern);

                if(!(matchLeft.Success && matchRight.Success))
                {
                    Console.WriteLine("ticket \"{0}\" - no match", s);
                    continue;
                }

                nLength = Math.Min(matchLeft.Length, matchRight.Length);

                if(matchLeft.Value[0] == matchRight.Value[0])
                {
                    if (nLength == 10)
                    {
                        Console.WriteLine("ticket \"{0}\" - {1}{2} Jackpot!", s, 10, matchLeft.Value[0]);
                    }
                    else
                    {
                        Console.WriteLine("ticket \"{0}\" - {1}{2}", s, nLength, matchLeft.Value[0]);
                    }

                    continue;
                }
                    
                Console.WriteLine("ticket \"{0}\" - no match", s);

            }

        }
    }
}
