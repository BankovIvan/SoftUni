using System;

namespace _05._Character_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {

            int i = 0;
            string s;

            s = Console.ReadLine();

            for(i=0; i<s.Length; i++)
            {
                Console.WriteLine((char)s[i]);
            }
        }
    }
}
