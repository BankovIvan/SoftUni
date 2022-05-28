using System;

namespace _09_Chars_to_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string s;

            s = "";

            s += char.Parse(Console.ReadLine());
            s += char.Parse(Console.ReadLine());
            s += char.Parse(Console.ReadLine());

            Console.WriteLine(s);

        }
    }
}
