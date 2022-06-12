using System;

namespace _09_Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string sData;

            sData = Console.ReadLine();

            while(sData != "END")
            {

                if (CheckPalindrome(int.Parse(sData)))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }

                sData = Console.ReadLine();

            }

        }

        private static bool CheckPalindrome(int nData)
        {
            string sData = nData.ToString();
            int i, j;

            for(i=0, j=sData.Length-1; j >= i; i++, j--)
            {
                if(sData[i] != sData[j])
                {
                    return false;
                }
            }

            return true;

        }
    }
}
