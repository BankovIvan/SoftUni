using System;

namespace _06_Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string sString;

            sString = Console.ReadLine();

            Console.WriteLine(MyPrintMiddle(sString));

        }

        private static string MyPrintMiddle(string sString)
        {

            string s = "";

            if (sString.Length <= 2)
            {
                s = sString;
            }
            else if((sString.Length & 1) == 1)
            {
                //even
                s = sString[sString.Length / 2].ToString();
            }
            else
            {
                //odd
                s = sString[(sString.Length / 2) - 1].ToString();
                s = s + sString[sString.Length / 2].ToString();
            }

            return s;

        }
    }
}
