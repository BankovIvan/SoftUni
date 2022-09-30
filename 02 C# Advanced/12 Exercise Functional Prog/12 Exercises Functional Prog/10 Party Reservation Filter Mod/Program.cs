namespace _10_Party_Reservation_Filter_Mod
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> lstGuests = Console
                                        .ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .ToList();
            Dictionary<string, Predicate<string>> lstFilters = new Dictionary<string, Predicate<string>>();

            while (true)
            {
                string[] arrFilter = Console
                                        .ReadLine()
                                        .Split(";", StringSplitOptions.RemoveEmptyEntries)
                                        .ToArray();

                if (arrFilter[0] == "Print")
                {
                    break;
                }

                //Predicate<string> p = GetPredicate(arrFilter[1], arrFilter[2]);

                if (arrFilter[0] == "Add filter")
                {
                    lstFilters.Add(arrFilter[1] + arrFilter[2], GetPredicate(arrFilter[1], arrFilter[2]));
                }
                else if (arrFilter[0] == "Remove filter")
                {
                    //if(lstFilters.ContainsKey(arrFilter[1] + arrFilter[2]))
                    //{
                        lstFilters.Remove(arrFilter[1] + arrFilter[2]);
                    //}
                    
                }

            }

            foreach(var v in lstFilters)
            {
                lstGuests.RemoveAll(v.Value);
            }

            Console.WriteLine(String.Join(" ", lstGuests));

        }

        private static Predicate<string> GetPredicate(string sCondition, string sValue)
        {
            if (sCondition == "Starts with")
            {
                return x => x.StartsWith(sValue);
            }
            else if (sCondition == "Ends with")
            {
                return x => x.EndsWith(sValue);
            }
            else if (sCondition == "Length")
            {
                return x => x.Length == int.Parse(sValue);
            }
            else if (sCondition == "Contains")
            {
                return x => x.Contains(sValue);
            }

            return default(Predicate<string>);
            //return x => false;
        }
    }
}