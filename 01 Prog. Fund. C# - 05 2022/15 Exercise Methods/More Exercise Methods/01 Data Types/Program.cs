using System;

namespace _01_Data_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            string sDataType;

            sDataType = Console.ReadLine();

            if (sDataType == "int")
            {
                PrintData(int.Parse(Console.ReadLine()));
            }
            else if (sDataType == "real")
            {
                PrintData(double.Parse(Console.ReadLine()));
            }
            else
            {
                PrintData(Console.ReadLine());
            }


        }

        private static void PrintData(int v)
        {
            Console.WriteLine(v * 2);
        }

        private static void PrintData(double v)
        {
            Console.WriteLine("{0:F2}", v * 1.5);
        }

        private static void PrintData(string v)
        {
            Console.WriteLine("$" + v + "$");
        }

    }
}
