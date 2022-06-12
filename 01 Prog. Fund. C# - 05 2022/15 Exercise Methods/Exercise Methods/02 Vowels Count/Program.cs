using System;

namespace _02_Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            //a, e, i, o, u

            string sDataString;

            sDataString = Console.ReadLine();

            Console.WriteLine(MyCountVowels(sDataString.ToLower()));

        }

        private static int MyCountVowels(string sDataString)
        {
            int i, nRet = 0;

            for(i = 0; i < sDataString.Length; i++)
            {
                switch (sDataString[i])
                {
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'o':
                    case 'u':

                        nRet++;
                        break;

                    default:

                        break;

                }
            }

            return nRet;

        }
    }
}
