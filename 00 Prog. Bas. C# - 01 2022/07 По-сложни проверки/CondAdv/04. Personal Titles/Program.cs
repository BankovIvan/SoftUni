using System;

namespace _04._Personal_Titles
{
    class Program
    {
        static void Main(string[] args)
        {

            double dAgeIn;
            char cGenderIn;

            dAgeIn = double.Parse(Console.ReadLine());
            cGenderIn = Console.ReadLine()[0];

            if(cGenderIn == 'm')
            {
                // m

                if(dAgeIn >= 16.0)
                {
                    Console.WriteLine("Mr.");
                }
                else
                {
                    Console.WriteLine("Master");
                }

            }
            else
            {
                // f

                if (dAgeIn >= 16.0)
                {
                    Console.WriteLine("Ms.");
                }
                else
                {
                    Console.WriteLine("Miss");
                }

            }

        }
    }
}
