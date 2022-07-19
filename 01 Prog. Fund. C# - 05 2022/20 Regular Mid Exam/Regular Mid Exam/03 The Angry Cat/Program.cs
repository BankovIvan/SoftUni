using System;

namespace _03_The_Angry_Cat
{
    class Program
    {
        static void Main(string[] args)
        {
            long nSumLeft, nSumRight;
            int i, nEntryIndex;
            string sItemType;
            int[] arrItemsPrice;

            arrItemsPrice = Array.ConvertAll(
                        Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries),
                        new Converter<string, int>(int.Parse)
                        );
            nEntryIndex = int.Parse(Console.ReadLine());
            sItemType = Console.ReadLine();
            nSumLeft = 0L;
            nSumRight = 0L;

            if (sItemType == "cheap")
            {
                for(i = 0; i < nEntryIndex; i++)
                {
                    if(arrItemsPrice[i] < arrItemsPrice[nEntryIndex])
                    {
                        nSumLeft += arrItemsPrice[i];
                    }
                }

                for (i = nEntryIndex + 1; i < arrItemsPrice.Length; i++)
                {
                    if (arrItemsPrice[i] < arrItemsPrice[nEntryIndex])
                    {
                        nSumRight += arrItemsPrice[i];
                    }
                }

            }
            else if (sItemType == "expensive")
            {
                for (i = 0; i < nEntryIndex; i++)
                {
                    if (arrItemsPrice[i] >= arrItemsPrice[nEntryIndex])
                    {
                        nSumLeft += arrItemsPrice[i];
                    }
                }

                for (i = nEntryIndex + 1; i < arrItemsPrice.Length; i++)
                {
                    if (arrItemsPrice[i] >= arrItemsPrice[nEntryIndex])
                    {
                        nSumRight += arrItemsPrice[i];
                    }
                }
            }

            if(nSumLeft >= nSumRight)
            {
                Console.WriteLine("Left - {0}", nSumLeft);
            }
            else
            {
                Console.WriteLine("Right - {0}", nSumRight);
            }
        }
    }
}
