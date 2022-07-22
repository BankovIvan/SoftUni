using System;

namespace M01_Extract_Person_Information
{
    class Program
    {
        static void Main(string[] args)
        {
            string sData, sName, sAge;
            int i, j, nStart, nCount, nRepeat;


            nRepeat = int.Parse(Console.ReadLine());

            for(i = 0; i < nRepeat; i++)
            {
                sData = Console.ReadLine();
                sName = "";
                sAge = "";
                nStart = 0;
                nCount = 0;

                for (j = 0; j < sData.Length; j++)
                {
                    if(sData[j] == '@')
                    {
                        nStart = j;
                    }
                    else if(sData[j] == '|')
                    {
                        nCount = j - nStart;
                        sName = sData.Substring(nStart+1, nCount-1);
                    }
                    else if (sData[j] == '#')
                    {
                        nStart = j;
                    }
                    else if (sData[j] == '*')
                    {
                        nCount = j - nStart;
                        sAge = sData.Substring(nStart+1, nCount-1);
                    }

                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("{0} is {1} years old.", sName, sAge);
                Console.ResetColor();

            }

        }
    }
}
