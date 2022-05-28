using System;

namespace _08_Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, nKegs;
            string sKegType, sMaxKegType;
            double dRadius, dHeight, dVolume, dMaxVolume;

            nKegs = int.Parse(Console.ReadLine());
            sMaxKegType = "";
            dMaxVolume = -0.1d;

            for (i = 0; i < nKegs; i++)
            {
                sKegType = Console.ReadLine();
                dRadius = double.Parse(Console.ReadLine());
                dHeight = double.Parse(Console.ReadLine());

                dVolume = Math.PI * dRadius * dRadius * dHeight;

                if(dVolume > dMaxVolume)
                {
                    dMaxVolume = dVolume;
                    sMaxKegType = sKegType;
                }

            }

            Console.WriteLine(sMaxKegType);

        }
    }
}
