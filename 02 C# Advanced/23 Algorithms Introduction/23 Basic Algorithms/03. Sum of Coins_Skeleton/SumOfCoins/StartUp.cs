namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] arrCoins = Array.ConvertAll(
                Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries),
                new Converter<string, int>(int.Parse));
            int nTargetSum = int.Parse(Console.ReadLine());
            int nTotalSum = 0;

            Dictionary<int, int> dicSelectedCoins = ChooseCoins(arrCoins, nTargetSum);
            foreach (var v in dicSelectedCoins)
            {
                nTotalSum += v.Value;
            }

            Console.WriteLine("Number of coins to take: {0}", nTotalSum);
            foreach(var v in dicSelectedCoins)
            {
                Console.WriteLine("{0} coin(s) with value {1}", v.Value, v.Key);
            }

        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int nTargetSum)
        {
            Dictionary<int, int> dicCoins = new Dictionary<int, int>(); 
            List<int> lstCoins = coins.ToList();
            lstCoins.Sort();
            //int nCurrecnSum = 0;
            
            for(int i = lstCoins.Count - 1; i >= 0; i--)
            {
                //int nRemainder = nTargetSum - nCurrecnSum;
                int nCurrentCoins = nTargetSum / lstCoins[i];

                if(nCurrentCoins > 0)
                {
                    nTargetSum -= nCurrentCoins * lstCoins[i];
                    dicCoins.Add(lstCoins[i], nCurrentCoins);

                    if(nTargetSum == 0)
                    {
                        return dicCoins;
                    }

                }

            }

            throw new InvalidOperationException();

            return dicCoins;
        }
    }
}