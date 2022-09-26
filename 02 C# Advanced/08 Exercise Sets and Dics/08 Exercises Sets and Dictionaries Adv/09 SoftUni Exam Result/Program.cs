using System;
using System.Collections.Generic;
using System.Linq;

namespace _09_SoftUni_Exam_Result
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dicResults = new Dictionary<string, int>();
            Dictionary<string, int> dicSubmissions = new Dictionary<string, int>();
            string[] arrInput;
            int nPoints = 0;

            while (true)
            {
                arrInput = Console.ReadLine().Split('-', StringSplitOptions.RemoveEmptyEntries);
                if(arrInput[0] == "exam finished")
                {
                    break;
                }

                if(arrInput[1] == "banned")
                {
                    if (dicResults.ContainsKey(arrInput[0]))
                    {
                        dicResults[arrInput[0]] = -1;
                    }
                    else
                    {
                        dicResults.Add(arrInput[0], -1);
                    }
                }
                else
                {
                    nPoints = int.Parse(arrInput[2]);

                    if (dicResults.ContainsKey(arrInput[0]))
                    {
                        if(dicResults[arrInput[0]] < nPoints)
                        {
                            dicResults[arrInput[0]] = nPoints;
                        }
                    }
                    else
                    {
                        dicResults.Add(arrInput[0], nPoints);
                    }

                    if (dicSubmissions.ContainsKey(arrInput[1]))
                    {
                        dicSubmissions[arrInput[1]]++;
                    }
                    else
                    {
                        dicSubmissions.Add(arrInput[1], 1);
                    }

                }

            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Results:");
            foreach (var v in dicResults.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                if(v.Value < 0)
                {
                    break;
                }
                Console.WriteLine("{0} | {1}", v.Key, v.Value);
            }

            Console.WriteLine("Submissions:");
            foreach (var v in dicSubmissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine("{0} - {1}", v.Key, v.Value);
            }
            Console.ResetColor();

        }
    }
}
