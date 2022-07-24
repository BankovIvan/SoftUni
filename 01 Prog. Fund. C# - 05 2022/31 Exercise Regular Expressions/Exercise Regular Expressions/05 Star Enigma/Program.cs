using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace _05_Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            string sPattern = @"[^@\-!:>]*?@(?<Name>[A-Za-z]+)[^@\-!:>]*?:(?<Population>[\d]+)[^@\-!:>]*?!(?<Type>[AD])![^@\-!:>]*?->(?<Count>[\d]+).*";
            //Regex regFullName = new Regex(sPattern);
            //Match matchOrder;
            Match matchAttack;

            string sInput, sMessage = "";
            int i, nRepeat;
            List<string> lstAtacked = new List<string>();
            List<string> lstDestroyed = new List<string>();

            nRepeat = int.Parse(Console.ReadLine());
            for(i = 0; i < nRepeat; i++)
            {
                sInput = Console.ReadLine();
                sMessage = DecryptMessage(sInput);

                matchAttack = Regex.Match(sMessage, sPattern);
                if (!matchAttack.Success)
                {
                    continue;
                }

                if(matchAttack.Groups["Type"].Value == "A")
                {
                    lstAtacked.Add(matchAttack.Groups["Name"].Value);
                }
                else
                {
                    lstDestroyed.Add(matchAttack.Groups["Name"].Value);
                }

            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Attacked planets: {0}", lstAtacked.Count);
            foreach(var v in lstAtacked.OrderBy(x => x))
            {
                Console.WriteLine("-> {0}", v);
            }
            Console.WriteLine("Destroyed planets: {0}", lstDestroyed.Count);
            foreach (var v in lstDestroyed.OrderBy(x => x))
            {
                Console.WriteLine("-> {0}", v);
            }
            Console.ResetColor();
        }

        private static string DecryptMessage(string sInput)
        {
            StringBuilder ret = new StringBuilder("");
            int j, nCount = 0;

            for (j = 0; j < sInput.Length; j++)
            {
                if (sInput[j] == 's' || sInput[j] == 'S' ||
                    sInput[j] == 't' || sInput[j] == 'T' ||
                    sInput[j] == 'a' || sInput[j] == 'A' ||
                    sInput[j] == 'r' || sInput[j] == 'R')
                {
                    nCount++;
                }
            }

            for (j = 0; j < sInput.Length; j++)
            {
                ret.Append((char)(sInput[j] - nCount));
            }

            return ret.ToString();

        }
    }
}
