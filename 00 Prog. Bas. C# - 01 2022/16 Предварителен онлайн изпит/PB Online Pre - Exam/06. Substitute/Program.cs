using System;

namespace _06._Substitute
{
    class Program
    {
        static void Main(string[] args)
        {

            int i = 0, j = 0, k = 0, l = 0, nK = 0, nL = 0, nM = 0, nN = 0, nCount = 0;

            nK = int.Parse(Console.ReadLine());
            nL = int.Parse(Console.ReadLine());
            nM = int.Parse(Console.ReadLine());
            nN = int.Parse(Console.ReadLine());

            for(i = nK; i <= 8; i++)
            {

                if((i & 1) == 1)
                {
                    continue;
                }

                for(j = 9; j >= nL; j--)
                {
                    
                    if ((j & 1) == 0)
                    {
                        continue;
                    }

                    //First number [i,j]

                    for(k = nM; k <= 8; k++)
                    {

                        if ((k & 1) == 1)
                        {
                            continue;
                        }

                        for(l = 9; l >= nN; l--)
                        {

                            if ((l & 1) == 0)
                            {
                                continue;
                            }


                            //Second number - [k,l]

                            if(i == k && j == l)
                            {
                                Console.WriteLine("Cannot change the same player.");
                            }
                            else
                            {
                                Console.WriteLine("{0}{1} - {2}{3}", i, j, k, l);


                                nCount++;

                                if (nCount >= 6)
                                {
                                    return;
                                }

                            }

                        }


                    }


                }

            }

        }
    }
}
