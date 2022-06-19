using System;
using System.Collections.Generic;

namespace _05_Drum_Set
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lstDrums; // = new List<int>();
            List<int> lstInitial; // = new List<int>();
            double dMoney, dDelta=0.0;
            string sCommand;
            int i, nHitPower;

            dMoney = double.Parse(Console.ReadLine());
            lstInitial = new List<int>(Array.ConvertAll(
                        Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                        new Converter<string, int>(int.Parse)
                        ));
            lstDrums = new List<int>(lstInitial);

            sCommand = Console.ReadLine();
            while(sCommand != "Hit it again, Gabsy!")
            {

                nHitPower = int.Parse(sCommand);

                for(i = 0; i < lstDrums.Count; i++)
                {
                    lstDrums[i] -= nHitPower;
                    if(lstDrums[i] <= 0)
                    {
                        dDelta = lstInitial[i] * 3.0;

                        if(dDelta > dMoney)
                        {
                            lstDrums.RemoveAt(i);
                            lstInitial.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            lstDrums[i] = lstInitial[i];
                            dMoney -= dDelta;
                        }

                    }

                }


                sCommand = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', lstDrums));
            Console.WriteLine("Gabsy has {0:F2}lv.", dMoney);

        }
    }
}
