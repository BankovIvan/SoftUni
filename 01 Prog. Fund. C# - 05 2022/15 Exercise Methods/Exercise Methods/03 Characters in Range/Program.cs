using System;

namespace _03_Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char cFirst, cSecond;

            cFirst = char.Parse(Console.ReadLine());
            cSecond = char.Parse(Console.ReadLine());


            if(cFirst < cSecond)
            {
                MyPrintCharactersInRangeg(++cFirst, --cSecond);
            }
            else
            {
                MyPrintCharactersInRangeg(++cSecond, --cFirst);
            }

        }

        private static void MyPrintCharactersInRangeg(char cFirst, char cSecond)
        {
            char c;

            for(c = cFirst; c <= cSecond; c++)
            {
                Console.Write(c);
                Console.Write(" ");
            }

            Console.WriteLine();

        }
    }
}
