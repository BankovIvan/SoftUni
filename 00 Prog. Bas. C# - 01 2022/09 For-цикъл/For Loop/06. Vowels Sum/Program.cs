using System;

namespace _06._Vowels_Sum
{
    class Program
    {
        static void Main(string[] args)
        {

            int i = 0, nVowels = 0;
            string sTextIn;

            sTextIn = Console.ReadLine();

            for(i=0; i<sTextIn.Length; i++)
            {
                switch ((char)sTextIn[i])
                {
                    case 'a':

                        nVowels += 1;
                        break;

                    case 'e':

                        nVowels += 2;
                        break;

                    case 'i':

                        nVowels += 3;
                        break;

                    case 'o':

                        nVowels += 4;
                        break;

                    case 'u':

                        nVowels += 5;
                        break;

                    default:

                        break;
                }
            }

            Console.WriteLine(nVowels);

        }
    }
}
