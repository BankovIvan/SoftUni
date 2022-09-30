namespace _09_Predicate_Party
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> lstPeople = Console
                                        .ReadLine()
                                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                        .ToList();

            Action<List<string>> fPrintPeople = x =>
            {
                if (x.Count > 0)
                {
                    Console.WriteLine("{0} are going to the party!", String.Join(", ", x));
                }
                else
                {
                    Console.WriteLine("Nobody is going to the party!");
                }
            };

            while (true)
            {
                string[] arrInput = Console.ReadLine().Split(' ', StringSplitOptions.None);
                if (arrInput[0] == "Party!")
                {
                    break;
                }

                Predicate<string> fNameCheck = GetNameCheck(arrInput[1], arrInput[2]);

                if (arrInput[0] == "Double")
                {
                    for (int i = 0; i < lstPeople.Count; i++)
                    {
                        if (fNameCheck(lstPeople[i]))
                        {
                            lstPeople.Insert(i, lstPeople[i]);
                            i++;
                        }
                    }

                }
                else if (arrInput[0] == "Remove")
                {
                    lstPeople.RemoveAll(x => fNameCheck(x));
                }
                

            }

            fPrintPeople(lstPeople);

        }

        private static Predicate<string> GetNameCheck(string sCondition, string sValue)
        {
            if(sCondition == "StartsWith")
            {
                return x => x.StartsWith(sValue);
            }
            else if(sCondition == "EndsWith")
            {
                return x => x.EndsWith(sValue);
            }
            else if (sCondition == "Length")
            {
                return x => x.Length == int.Parse(sValue);
            }

            return null;

        }
    }
}