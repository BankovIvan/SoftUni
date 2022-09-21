using System;
using System.Collections.Generic;

namespace _08_SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> setVIPGuests = new HashSet<string>();
            HashSet<string> setRegularGuests = new HashSet<string>();
            string sInput;
            bool bParty = false;

            while (true)
            {
                sInput = Console.ReadLine();
                if(sInput == "PARTY")
                {
                    bParty = true;
                }
                else if(sInput == "END")
                {
                    break;
                }
                else
                {
                    if (!bParty)
                    {
                        if(sInput[0] >= '0' && sInput[0] <= '9')
                        {
                            // VIP
                            setVIPGuests.Add(sInput);
                        }
                        else
                        {
                            // REGULAR
                            setRegularGuests.Add(sInput);
                        }
                    }
                    else
                    {
                        if (sInput[0] >= '0' && sInput[0] <= '9')
                        {
                            // VIP
                            setVIPGuests.Remove(sInput);
                        }
                        else
                        {
                            // REGULAR
                            setRegularGuests.Remove(sInput);
                        }
                    }
                }
            }

            Console.WriteLine(setVIPGuests.Count + setRegularGuests.Count);
            if(setVIPGuests.Count > 0)
            {
                Console.WriteLine(string.Join('\n', setVIPGuests));
            }
            if(setRegularGuests.Count > 0)
            {
                Console.WriteLine(string.Join('\n', setRegularGuests));
            }

        }
    }
}
