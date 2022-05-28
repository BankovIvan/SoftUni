using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    const double PRECISION = (1.0 / (double)int.MaxValue);

    static void Main(string[] args)
    {
        int numer, denom, i;
        double finalValue;
        string s;
        List<int> fractionsFound = new List<int>();

        s = Console.ReadLine();
        numer = s.Split('/').Select(int.Parse).ToArray().First();
        denom = s.Split('/').Select(int.Parse).ToArray().Last();

        finalValue = ((double)numer) / ((double)denom);
        if(finalValue >= 1.0)
        {
            Console.WriteLine("Error (fraction is equal to or greater than 1)");
            return;
        }

        ComputeEgyptionFractions(fractionsFound, finalValue);

        s = "";
        for(i = 0; i < fractionsFound.Count; i++)
        {
            s = (s == "") ? numer + "/" + denom + " = 1/" + fractionsFound[i] : s + " + 1/" + fractionsFound[i];

        }

        Console.WriteLine(s);

        return;

    }

    private static void ComputeEgyptionFractions(List<int> fractionsFound, double finalValue)
    {
        int i;
        double addedValue;
        double reachedValue = 0.0;

        for (i = 2; i < int.MaxValue; i++)
        {
            addedValue = 1.0 / (double)i;

            if(reachedValue + addedValue <= finalValue)
            {
                fractionsFound.Add(i);
                reachedValue += addedValue;
                if (Math.Abs(finalValue - reachedValue) <= PRECISION) break;

            }

        }

    }
}