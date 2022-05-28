using System;

namespace _02._Greater
{
    class Program
    {
        static void Main(string[] args)
        {

            int nNum1, nNum2;

            nNum1 = int.Parse(Console.ReadLine());
            nNum2 = int.Parse(Console.ReadLine());

            if(nNum1 > nNum2)
            {
                Console.WriteLine(nNum1);
            }
            else
            {
                Console.WriteLine(nNum2);
            }

        }
    }
}
