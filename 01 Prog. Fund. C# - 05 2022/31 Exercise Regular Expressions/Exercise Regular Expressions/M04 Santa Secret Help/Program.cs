using System;
using System.Text;
using System.Text.RegularExpressions;

namespace M04_Santa_Secret_Help
{
    class Program
    {
        static void Main(string[] args)
        {
            string sPattern = @"@(?<Name>[A-Za-z]+)[^\@\-\!\:\>]*!(?<Type>[GN])!";
            string sInput;
            StringBuilder sMessage;
            int nCipher;

            nCipher = int.Parse(Console.ReadLine());

            while (true)
            {
                sInput = Console.ReadLine();
                if(sInput == "end")
                {
                    break;
                }

                sMessage = new StringBuilder();
                foreach(char c in sInput)
                {
                    sMessage.Append((char)(c - nCipher));
                }

                Match m = Regex.Match(sMessage.ToString(), sPattern);
                if (m.Success)
                {
                    if(m.Groups["Type"].Value == "G")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(m.Groups["Name"].Value);
                        Console.ResetColor();
                    }
                }
            }
        }
    }
}
