using System;

namespace _1._Data_Type_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            string sData;

            sData = Console.ReadLine();

            while (sData != "END")
            {

                if(int.TryParse(sData, out _) == true)
                {
                    Console.WriteLine("{0} is integer type", sData);
                }
                else if (float.TryParse(sData, out _) == true)
                {
                    Console.WriteLine("{0} is floating point type", sData);
                }
                else if (char.TryParse(sData, out _) == true)
                {
                    Console.WriteLine("{0} is character type", sData);
                }
                else if (bool.TryParse(sData, out _) == true)
                {
                    Console.WriteLine("{0} is boolean type", sData);
                }
                else
                {
                    Console.WriteLine("{0} is string type", sData);
                }

                sData = Console.ReadLine();

            }

        }
    }
}
