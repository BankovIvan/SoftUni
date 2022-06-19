using System;

namespace _02_Car_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arrNumbers; // = new List<int>();
            int i, nMiddle;
            double dLeftCar, dRightCar;

            //lstLessons = new List<string>(Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries));

            arrNumbers = Array.ConvertAll(
                        Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                        new Converter<string, double>(double.Parse)
                        );

            nMiddle = (arrNumbers.Length / 2);
            dLeftCar = 0.0;
            dRightCar = 0.0;

            for (i = 0; i < nMiddle; i++)
            {
                if(Math.Abs(arrNumbers[i]) < 0.0001)
                {
                    dLeftCar = dLeftCar * 0.8;
                }
                else
                {
                    dLeftCar += arrNumbers[i];
                }
            }

            for (i = arrNumbers.Length-1; i > nMiddle; i--)
            {
                if (Math.Abs(arrNumbers[i]) < 0.0001)
                {
                    dRightCar *= 0.8;
                }
                else
                {
                    dRightCar += arrNumbers[i];
                }
            }

            if(dLeftCar <= dRightCar)
            {
                Console.WriteLine("The winner is left with total time: {0}", Math.Round(dLeftCar, 4));
            }
            else
            {
                Console.WriteLine("The winner is right with total time: {0}", Math.Round(dRightCar, 4));
            }

        }
    }
}
