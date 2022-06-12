using System;
using System.Text;

namespace _07_Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string sString;
            int nRepeat;

            sString = Console.ReadLine();
            nRepeat = int.Parse(Console.ReadLine());

            Console.WriteLine(MyStringRepeat(sString, nRepeat));

        }

        private static string MyStringRepeat(string sString, int nRepeat)
        {
            StringBuilder sRet = new StringBuilder();
            int i;

            for(i = 0; i < nRepeat; i++)
            {
                sRet.Append(sString);
            }

            return sRet.ToString();

        }
    }
}
