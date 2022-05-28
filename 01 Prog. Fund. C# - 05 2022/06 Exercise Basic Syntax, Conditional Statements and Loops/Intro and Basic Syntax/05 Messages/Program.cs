using System;

namespace _05_Messages
{
    class Program
    {
        static void Main(string[] args)
        {

            string s;
            //char c;
            int i, num, offset;

            i = int.Parse(Console.ReadLine());

            //s = Console.ReadLine();
            //num = s[0] - '0';
            //offset = 0;

            for(; i > 0; i--)
            {

                s = Console.ReadLine();
                num = s[0] - '0';

                offset = ((num - 2) * 3) + s.Length - 1;

                if (num > 7)
                {
                    offset++;
                }

                if(s == "0")
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write((char)(97 + offset));
                }
                

                //s = Console.ReadLine();
                //num = s[0] - '0';

            }

            Console.WriteLine();

        }
    }
}
