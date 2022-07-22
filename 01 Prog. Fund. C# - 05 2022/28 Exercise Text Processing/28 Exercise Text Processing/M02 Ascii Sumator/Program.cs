using System;

namespace M02_Ascii_Sumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char cFirst, cLast, cTemp;
            string sData;
            int i, nSum = 0;

            cFirst = char.Parse(Console.ReadLine());
            cLast = char.Parse(Console.ReadLine());
            sData = Console.ReadLine();

            if(cFirst > cLast)
            {
                cTemp = cFirst;
                cFirst = cLast;
                cLast = cTemp;
            }

            for(i = 0; i < sData.Length; i++)
            {
                if(sData[i] > cFirst && sData[i] < cLast)
                {
                    nSum += (int)sData[i];
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(nSum);
            Console.ResetColor();

        }
    }
}
