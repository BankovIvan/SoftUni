namespace _06_Money_Transactions
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arrInput = Console.ReadLine().Split(new char[] {',', '-'}, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<int, double> dicAccounts = new Dictionary<int, double>();

            for(int i = 0; i < arrInput.Length; i += 2)
            {
                dicAccounts.Add(int.Parse(arrInput[i]), double.Parse(arrInput[i+1]));
            }

            while((arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries))[0] != "End")
            {
                try
                {
                    if (arrInput[0] == "Deposit")
                    {
                        int account = int.Parse(arrInput[1]);
                        double cash = double.Parse(arrInput[2]);
                        dicAccounts[account] += cash;

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Account {0} has new balance: {1:F2}", account, dicAccounts[account]);
                        Console.ResetColor();
                    }
                    else if (arrInput[0] == "Withdraw")
                    {
                        int account = int.Parse(arrInput[1]);
                        double cash = double.Parse(arrInput[2]);
                        if (dicAccounts[account] < cash)
                        {
                            throw new ArgumentException("Insufficient balance!");
                        }
                        dicAccounts[account] -= cash;

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Account {0} has new balance: {1:F2}", account, dicAccounts[account]);
                        Console.ResetColor();
                    }
                    else
                    {
                        throw new ArgumentException("Invalid command!");
                    }
                }
                catch(KeyNotFoundException ex)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid account!");
                    Console.ResetColor();
                }
                catch(ArgumentException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }
                finally
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Enter another command");
                    Console.ResetColor();
                }
            }

        }
    }
}
