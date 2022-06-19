using System;
using System.Collections.Generic;

namespace _07_List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sCommand;
            List<int> lstNumbers; // = new List<int>();
            int i, nSum;
            bool bChanged = false;

            lstNumbers = new List<int>(Array.ConvertAll(
                                    Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                                    new Converter<string, int>(int.Parse)
                                    ));

            sCommand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (sCommand[0] != "end")
            {

                switch (sCommand[0])
                {
                    case "Add":
                        lstNumbers.Add(int.Parse(sCommand[1]));
                        bChanged = true;
                        break;

                    case "Remove":
                        lstNumbers.Remove(int.Parse(sCommand[1]));
                        bChanged = true;
                        break;

                    case "RemoveAt":
                        lstNumbers.RemoveAt(int.Parse(sCommand[1]));
                        bChanged = true;
                        break;

                    case "Insert":
                        lstNumbers.Insert(int.Parse(sCommand[2]), int.Parse(sCommand[1]));
                        bChanged = true;
                        break;

                    case "Contains":
                        if (lstNumbers.Contains(int.Parse(sCommand[1])))
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;

                    case "PrintEven":
                        for(i = 0; i < lstNumbers.Count; i++)
                        {
                            if((lstNumbers[i] & 1) == 0)
                            {
                                Console.Write("{0} ", lstNumbers[i]);
                            }
                            
                        }
                        Console.WriteLine();
                        break;

                    case "PrintOdd":
                        for (i = 0; i < lstNumbers.Count; i++)
                        {
                            if ((lstNumbers[i] & 1) == 1)
                            {
                                Console.Write("{0} ", lstNumbers[i]);
                            }

                        }
                        Console.WriteLine();
                        break;

                    case "GetSum":
                        nSum = 0;
                        for (i = 0; i < lstNumbers.Count; i++)
                        {
                            nSum += lstNumbers[i];

                        }
                        Console.WriteLine(nSum);
                        break;

                    case "Filter":
                        nSum = int.Parse(sCommand[2]);
                        for (i = 0; i < lstNumbers.Count; i++)
                        {
                            if (sCommand[1] == "<" && lstNumbers[i] < nSum)
                            {
                                Console.Write("{0} ", lstNumbers[i]);
                            }
                            else if (sCommand[1] == ">" && lstNumbers[i] > nSum)
                            {
                                Console.Write("{0} ", lstNumbers[i]);
                            }
                            else if (sCommand[1] == ">=" && lstNumbers[i] >= nSum)
                            {
                                Console.Write("{0} ", lstNumbers[i]);
                            }
                            else if (sCommand[1] == "<=" && lstNumbers[i] <= nSum)
                            {
                                Console.Write("{0} ", lstNumbers[i]);
                            }

                        }
                        Console.WriteLine();
                        break;

                    default:

                        break;
                }

                sCommand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            if (bChanged)
            {
                Console.WriteLine(string.Join(' ', lstNumbers));
            }

        }
    }
}
