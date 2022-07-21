using System;

namespace _01_Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrUserNames = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            foreach(var v in arrUserNames)
            {
                if (IsValidUserName(v))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(v);
                    Console.ResetColor();
                }
            }
        }

        private static bool IsValidUserName(string sUserName)
        {
            bool ret = true;

            foreach(char c in sUserName)
            {
                if (sUserName.Length < 3 || sUserName.Length > 16)
                {
                    ret = false;
                    break;
                }
                if (!(char.IsLetterOrDigit(c) || c == '_' || c == '-'))
                {
                    ret = false;
                    break;
                }
            }

            return ret;
        }
    }
}
