using System;

namespace _05._Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            int i = 0, nInput = 600000, nSpecial = 0, nReminder = 0, nCounter = 0;

            nInput = int.Parse(Console.ReadLine());

            for(i = 1111; i <= 9999; i++)
            {

                nSpecial = i;
                nCounter = 0;

                while(nSpecial > 0) 
                {

                    nReminder = nSpecial % 10;

                    if(nReminder == 0)
                    {
                        break;
                    }
                    else if((nInput % nReminder) == 0)
                    {
                        nCounter++;
                    }
                    else
                    {
                        break;
                    }

                    nSpecial = nSpecial / 10;
                }

                if(nCounter == 4)
                {
                    Console.Write(i + " ");
                }

            }

        }
    }
}
