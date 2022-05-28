using System;

namespace _04._Easter_Eggs_Battle
{
    class Program
    {
        static void Main(string[] args)
        {

            int nEggsOne = 0, nEggsTwo = 0;
            string sInput = "";

            nEggsOne = int.Parse(Console.ReadLine());
            nEggsTwo = int.Parse(Console.ReadLine());

            sInput = Console.ReadLine();

            while (sInput != "End of battle")
            {

                if(sInput == "one")
                {
                    nEggsTwo--;
                }
                else if (sInput == "two")
                {
                    nEggsOne--;
                }

                if(nEggsOne <= 0)
                {
                    //Console.WriteLine("Player one is out of eggs.");
                    Console.WriteLine("Player one is out of eggs. Player two has {0} eggs left.", nEggsTwo);
                    return;
                }
                else if (nEggsTwo <= 0)
                {
                    Console.WriteLine("Player two is out of eggs. Player one has {0} eggs left.", nEggsOne);
                    //Console.WriteLine("Player two is out of eggs.");
                    return;
                }


                sInput = Console.ReadLine();
            }

            Console.WriteLine("Player one has {0} eggs left.", nEggsOne);
            Console.WriteLine("Player two has {0} eggs left.", nEggsTwo);

        }
    }
}
