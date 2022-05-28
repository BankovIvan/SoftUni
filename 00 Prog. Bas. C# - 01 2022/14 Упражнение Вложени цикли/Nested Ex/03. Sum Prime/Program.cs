using System;

namespace _03._Sum_Prime
{
    class Program
    {
        static void Main(string[] args)
        {

            string sInput = "";
            int i = 0, nNumber = 0, nSumPrime = 0, nSumNonPrime = 0;
            bool bPrime = false;

            sInput = Console.ReadLine();

            while(sInput != "stop")
            {

                nNumber = int.Parse(sInput);

                if(nNumber < 0)
                {
                    Console.WriteLine("Number is negative.");
                }
                else if (nNumber < 2)
                {
                    nSumPrime += nNumber;
                }
                else
                {

                    bPrime = true;

                    for (i = 2; i < nNumber; i++)
                    {
                        if((nNumber % i) == 0)
                        {
                            bPrime = false;
                            break;
                        }
                    }

                    if(bPrime == true)
                    {
                        nSumPrime += nNumber;
                    }
                    else
                    {
                        nSumNonPrime += nNumber;
                    }

                }

                sInput = Console.ReadLine();

            }

            Console.WriteLine("Sum of all prime numbers is: {0}", nSumPrime);
            Console.WriteLine("Sum of all non prime numbers is: {0}", nSumNonPrime);

        }
    }
}
