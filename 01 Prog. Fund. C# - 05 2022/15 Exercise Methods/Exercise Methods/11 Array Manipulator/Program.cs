using System;

namespace _11_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrArray;
            string[] sCommand;

            arrArray = Array.ConvertAll(
                                                Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                                                new Converter<string, int>(int.Parse)
                                                );

            sCommand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (sCommand[0] != "end")
            {

                if(sCommand[0] == "exchange")
                {
                    arrArray = ExchangeAndPrint(arrArray, sCommand);
                }
                else if (sCommand[0] == "max") 
                {
                    PrintMax(arrArray, sCommand);
                }
                else if (sCommand[0] == "min")
                {
                    PrintMin(arrArray, sCommand);
                }
                else if (sCommand[0] == "first")
                {
                    PrintFirstN(arrArray, sCommand);
                }
                else if (sCommand[0] == "last")
                {
                    PrintLastN(arrArray, sCommand);
                }

                sCommand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            }

            Console.WriteLine("[" + string.Join(", ", arrArray) + "]");

        }

        private static void PrintLastN(int[] arrArray, string[] sCommand)
        {
            int i, nEven = 0, nPrinted = 0, nToPrint = int.Parse(sCommand[1]);
            string sPrint = "";

            if (nToPrint > arrArray.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            /*
            if (nToPrint == 0)
            {
                Console.WriteLine("[]");
                return;
            }

            if (nToPrint < 0)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            */

            if (sCommand[2] == "odd")
            {
                nEven = 1;
            }

            for (i = arrArray.Length - 1; i >= 0; i--)
            {
                if ((arrArray[i] & 1) == nEven)
                {
                    if (nPrinted == 0)
                    {
                        sPrint = arrArray[i].ToString();
                    }
                    else
                    {
                        sPrint = arrArray[i].ToString() + ", " + sPrint;
                    }

                    nPrinted++;
                    if (nPrinted >= nToPrint)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine("[" + sPrint + "]");

        }

        private static void PrintFirstN(int[] arrArray, string[] sCommand)
        {
            int i, nEven = 0, nPrinted = 0, nToPrint = int.Parse(sCommand[1]);
            string sPrint = "";

            if(nToPrint > arrArray.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            /*
            if (nToPrint == 0)
            {
                Console.WriteLine("[]");
                return;
            }

            if (nToPrint < 0)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            */

            if (sCommand[2] == "odd")
            {
                nEven = 1;
            }

            for(i = 0; i < arrArray.Length; i++)
            {
                if((arrArray[i] & 1) == nEven)
                {
                    if(nPrinted == 0)
                    {
                        sPrint = arrArray[i].ToString();
                    }
                    else
                    {
                        sPrint = sPrint + ", " + arrArray[i].ToString();
                    }

                    nPrinted++;
                    if(nPrinted >= nToPrint)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine("[" + sPrint + "]");

        }

        private static void PrintMin(int[] arrArray, string[] sCommand)
        {
            int i, nMin = int.MaxValue, index = -1, nEven = 0;

            if (sCommand[1] == "odd")
            {
                nEven = 1;
            }

            for (i = 0; i < arrArray.Length; i++)
            {
                if ((arrArray[i] & 1) == nEven)
                {
                    if (nMin >= arrArray[i])
                    {
                        nMin = arrArray[i];
                        index = i;
                    }
                }
            }

            if (index >= 0)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("No matches");
            }

        }

        private static void PrintMax(int[] arrArray, string[] sCommand)
        {
            int i, nMax = int.MinValue, index = -1, nEven = 0;

            if(sCommand[1] == "odd")
            {
                nEven = 1;
            }

            for(i = 0; i < arrArray.Length; i++)
            {
                if((arrArray[i] & 1) == nEven)
                {
                    if (nMax <= arrArray[i])
                    {
                        nMax = arrArray[i];
                        index = i;
                    }
                }
            }

            if(index >= 0)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("No matches");
            }

        }

        private static int[] ExchangeAndPrint(int[] arrArray, string[] sCommand)
        {
            int i, j, index = int.Parse(sCommand[1]);
            int[] buffer = new int[arrArray.Length];

            if(index < 0 || index >= arrArray.Length)
            {
                Console.WriteLine("Invalid index");
                return arrArray;
            }

            for(i = 0, j = index + 1; j < arrArray.Length; i++, j++)
            {
                buffer[i] = arrArray[j];
            }

            for (j = 0; i < arrArray.Length; i++, j++)
            {
                buffer[i] = arrArray[j];
            }

            //Console.WriteLine("[" + string.Join(", ", buffer) + "]");
            return buffer;

        }
    }
}
