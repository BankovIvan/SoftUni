using System;
using System.Collections.Generic;

namespace _02_Change_List
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] sCommand;
            List<int> lstNumbers; // = new List<int>();
            int i, nLimit, nParam;

            lstNumbers = new List<int>(Array.ConvertAll(
                                    Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                                    new Converter<string, int>(int.Parse)
                                    ));

            //nLimit = int.Parse(Console.ReadLine());

            sCommand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (sCommand[0] != "end")
            {
                if (sCommand[0] == "Insert")
                {
                    lstNumbers.Insert(int.Parse(sCommand[2]), int.Parse(sCommand[1]));
                }
                else
                {
                    nParam = int.Parse(sCommand[1]);

                    // LAMBDA FUNCTION
                    // bool MyLambda( int nCheck ) { return nCheck == nParam; }
                    lstNumbers.RemoveAll( nCheck => nCheck == nParam);

                }

                sCommand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine(string.Join(' ', lstNumbers));


        }

    }
}
