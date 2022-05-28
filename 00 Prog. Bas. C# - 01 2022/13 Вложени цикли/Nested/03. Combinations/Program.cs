using System;

namespace _03._Combinations
{
    class Program
    {
        static void Main(string[] args)
        {

            int x1 = 0, x2 = 0, x3 = 0, nCombi = 0, nCount = 0;

            nCombi = int.Parse(Console.ReadLine());

            for(x1 = 0; x1 <= nCombi; x1++)
            {
                for(x2 = 0; x2 <= nCombi; x2++)
                {
                    for(x3 = 0; x3 <= nCombi; x3++)
                    {
                        if((x1 + x2 + x3) == nCombi)
                        {
                            nCount++;
                        }
                    }
                }
            }

            Console.WriteLine(nCount);

        }
    }
}
