using System;

namespace _09_Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string sDataType, sVar1, sVar2;

            sDataType = Console.ReadLine();
            sVar1 = Console.ReadLine();
            sVar2 = Console.ReadLine();

            if (sDataType == "int")
            {
                Console.WriteLine(MyGetMax(int.Parse(sVar1), int.Parse(sVar2)));
            }
            else if (sDataType == "string")
            {
                Console.WriteLine(MyGetMax(sVar1, sVar2));
            }
            else
            {
                Console.WriteLine(MyGetMax(sVar1[0], sVar2[0]));
            }

        }

        private static int MyGetMax(int v1, int v2)
        {
            int nRet = v1;
            if(v2 > v1)
            {
                nRet = v2;
            }

            return nRet;
        }

        private static string MyGetMax(char v1, char v2)
        {
            char cRet = v1;
            if (v2 > v1)
            {
                cRet = v2;
            }

            return cRet.ToString();
        }

        private static string MyGetMax(string v1, string v2)
        {
            string sRet = v1;
            if (string.Compare(v1, v2) < 0)
            {
                sRet = v2;
            }

            return sRet;
        }

    }
}
