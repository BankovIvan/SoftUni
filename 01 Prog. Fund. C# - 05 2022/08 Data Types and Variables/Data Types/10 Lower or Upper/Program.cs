using System;

namespace _10_Lower_or_Upper
{
    class Program
    {
        static void Main(string[] args)
        {

            char c;

            c = char.Parse(Console.ReadLine());

            if(c < 'a')
            {
                Console.WriteLine("upper-case");
            }
            else
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
