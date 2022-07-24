using System;

namespace _06_Balanced_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, nLoops;
            string sData;
            bool bBracketBalance;

            bBracketBalance = false;

            nLoops = int.Parse(Console.ReadLine());

            for(i = 0; i < nLoops; i++)
            {
                sData = Console.ReadLine();

                if (sData == "(")
                {
                    if(bBracketBalance == true)
                    {
                        Console.WriteLine("UNBALANCED");
                        return;
                    }

                    bBracketBalance = true;

                }
                else if (sData == ")")
                {
                    if (bBracketBalance == false)
                    {
                        Console.WriteLine("UNBALANCED");
                        return;
                    }

                    bBracketBalance = false;

                }

            }

            if (bBracketBalance == false)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }

        }
    }
}
