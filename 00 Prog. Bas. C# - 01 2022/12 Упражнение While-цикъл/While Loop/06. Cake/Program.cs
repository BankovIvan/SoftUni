using System;

namespace _06._Cake
{
    class Program
    {
        static void Main(string[] args)
        {

            int nCakeSize = 0;
            string sBitsData = "";

            nCakeSize = int.Parse(Console.ReadLine());
            nCakeSize *= int.Parse(Console.ReadLine());

            while (nCakeSize > 0)
            {
                sBitsData = Console.ReadLine();
                if(sBitsData == "STOP")
                {
                    break;
                }

                nCakeSize -= int.Parse(sBitsData);
            }

            if (nCakeSize >= 0)
            {
                Console.WriteLine("{0} pieces are left.", nCakeSize);
            }
            else
            {
                nCakeSize *= -1;
                Console.WriteLine("No more cake left! You need {0} pieces more.", nCakeSize);

            }

        }
    }
}
