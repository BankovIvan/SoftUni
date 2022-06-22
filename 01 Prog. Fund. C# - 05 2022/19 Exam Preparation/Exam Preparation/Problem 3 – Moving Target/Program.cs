using System;
using System.Collections.Generic;

namespace Problem_3___Moving_Target
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lstTargets; // = new List<int>();
            string[] arrCommand;

            lstTargets = new List<int>(Array.ConvertAll(
                        Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                        new Converter<string, int>(int.Parse)
                        ));

            arrCommand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while(arrCommand[0] != "End")
            {

                switch (arrCommand[0])
                {

                    case "Shoot":
                        ShootTarget(lstTargets, int.Parse(arrCommand[1]), int.Parse(arrCommand[2]));
                        break;

                    case "Add":
                        AddTarget(lstTargets, int.Parse(arrCommand[1]), int.Parse(arrCommand[2]));
                        break;

                    case "Strike":
                        StrikeTarget(lstTargets, int.Parse(arrCommand[1]), int.Parse(arrCommand[2]));
                        break;

                    default:

                        break;
                }



                arrCommand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            }

            Console.WriteLine(string.Join('|', lstTargets));

        }

        private static void StrikeTarget(List<int> lstTargets, int nIndex, int nRadius)
        {
            int nFirst, nLast;

            nFirst = nIndex - nRadius;
            nLast = nIndex + nRadius;

            if (nFirst < 0 || nLast >= lstTargets.Count)
            {
                Console.WriteLine("Strike missed!");
                return;
            }

            lstTargets.RemoveRange(nFirst, (nLast - nFirst) + 1);

            return;

        }

        private static void AddTarget(List<int> lstTargets, int nIndex, int nValue)
        {
            if (nIndex < 0 || nIndex >= lstTargets.Count)
            {
                Console.WriteLine("Invalid placement!");
                return;
            }

            lstTargets.Insert(nIndex, nValue);

            return;

        }

        private static void ShootTarget(List<int> lstTargets, int nIndex, int nPower)
        {
            if(nIndex < 0 || nIndex >= lstTargets.Count)
            {
                return;
            }

            lstTargets[nIndex] -= nPower;

            if(lstTargets[nIndex] <= 0)
            {
                lstTargets.RemoveAt(nIndex);
            }

            return;

        }
    }
}
