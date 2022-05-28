using System;

namespace _06._Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {

            int nMin = -1000, nData = -1000;
            string sData = "";

            sData = Console.ReadLine();

            while(sData != "Stop")
            {
                nData = int.Parse(sData);

                if(nMin < nData)
                {
                    nMin = nData;
                }

                sData = Console.ReadLine();

            }

            Console.WriteLine(nMin);

        }
    }
}
