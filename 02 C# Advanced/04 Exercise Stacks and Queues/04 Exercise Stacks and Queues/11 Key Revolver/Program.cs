using System;
using System.Collections.Generic;

namespace _11_Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int nBulletPrice = int.Parse(Console.ReadLine());
            int nBarrelSize = int.Parse(Console.ReadLine());
            Stack<int> stckBullets = new Stack<int>(Array.ConvertAll(
                    Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                    new Converter<string, int>(int.Parse)));
            Queue<int> qLocks = new Queue<int>(Array.ConvertAll(
                    Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                    new Converter<string, int>(int.Parse)));
            int nValue = int.Parse(Console.ReadLine());
            int nInitialBullets = stckBullets.Count;
            int nBarrelLoad = nBarrelSize;
            int nBulletSize = 0;

            while(stckBullets.Count > 0 && qLocks.Count > 0)
            {
                nBulletSize = stckBullets.Pop();

                if (qLocks.Peek() >= nBulletSize)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Bang!");
                    Console.ResetColor();

                    qLocks.Dequeue();
                    /*
                    if(qLocks.Count == 0)
                    {
                        break;
                    }
                    */
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Ping!");
                    Console.ResetColor();
                }

                nBarrelLoad--;
                if (nBarrelLoad < 1 && stckBullets.Count > 0)
                {
                    nBarrelLoad = nBarrelSize;

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Reloading!");
                    Console.ResetColor();
                }

            }

            if (qLocks.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Couldn't get through. Locks left: {0}", qLocks.Count);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("{0} bullets left. Earned ${1}", stckBullets.Count, 
                                        nValue - (nInitialBullets - stckBullets.Count) * nBulletPrice);
                Console.ResetColor();
            }

        }
    }
}
