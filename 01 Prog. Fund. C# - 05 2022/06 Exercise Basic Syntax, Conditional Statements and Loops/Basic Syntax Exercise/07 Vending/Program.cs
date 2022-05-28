using System;

namespace _07_Vending
{
    class Program
    {
        static void Main(string[] args)
        {
            double dMoneyTotal;
            string sInput;

            ///////////////////////////////////////////////////////////
            sInput = Console.ReadLine();
            dMoneyTotal = 0.0;

            while (sInput != "Start")
            {
                if(sInput != "0.1" && sInput != "0.2" && sInput != "0.5" && sInput != "1" && sInput != "2")
                {
                    Console.WriteLine("Cannot accept {0}", sInput);
                    
                }
                else
                {
                    dMoneyTotal += double.Parse(sInput);
                }

                sInput = Console.ReadLine();

            }

            ///////////////////////////////////////////////////////////////////
            sInput = Console.ReadLine();

            while (sInput != "End")
            {
                if (sInput == "Nuts")
                {
                    if(dMoneyTotal >= 2.0)
                    {
                        dMoneyTotal -= 2.0;
                        Console.WriteLine("Purchased nuts");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }

                }
                else if (sInput == "Water")
                {
                    if (dMoneyTotal >= 0.7)
                    {
                        dMoneyTotal -= 0.7;
                        Console.WriteLine("Purchased water");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }

                }
                else if (sInput == "Crisps")
                {
                    if (dMoneyTotal >= 1.5)
                    {
                        dMoneyTotal -= 1.5;
                        Console.WriteLine("Purchased crisps");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }

                }
                else if (sInput == "Soda")
                {
                    if (dMoneyTotal >= 0.8)
                    {
                        dMoneyTotal -= 0.8;
                        Console.WriteLine("Purchased soda");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }

                }
                else if (sInput == "Coke")
                {
                    if (dMoneyTotal >= 1.0)
                    {
                        dMoneyTotal -= 1.0;
                        Console.WriteLine("Purchased coke");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }

                }
                else
                {
                    Console.WriteLine("Invalid product");
                }

                sInput = Console.ReadLine();

            }

            Console.WriteLine("Change: {0:F2}", dMoneyTotal);

        }
    }
}
