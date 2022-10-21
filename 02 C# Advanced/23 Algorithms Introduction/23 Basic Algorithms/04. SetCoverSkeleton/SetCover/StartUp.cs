namespace SetCover
{
    using System;
    using System.Collections.Generic;
    //using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            int[] universe = Array.ConvertAll(
                Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries),
                new Converter<string, int>(int.Parse));

            int nSets = int.Parse(Console.ReadLine());

            int[][] sets = new int[nSets][];

            for (int i = 0; i < nSets; i++)
            {
                sets[i] = Array.ConvertAll(
                Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries),
                new Converter<string, int>(int.Parse));
            }

            List<int[]> lstSelectedSets = ChooseSets(sets, universe);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Sets to take ({0}):", lstSelectedSets.Count);
            foreach(var v in lstSelectedSets)
            {
                Console.WriteLine("{{ {0} }}", String.Join(", ", v));
            }
            Console.ResetColor();

        }

        public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
        {
            
            HashSet<int> setUniverse = new HashSet<int>(universe);
            List<int[]> lstSets = new List<int[]>(sets);
            List<int[]> ret = new List<int[]>();

            Func<HashSet<int>, int[], int> CountElements = (u, s) =>
            {
                int ret = 0;

                foreach(var v in s) if(u.Contains(v)) ret++;

                return ret;
            };

            Func<HashSet<int>, List<int[]>, int> MaxElementsIndex = (u, s) =>
            {
                int ret = 0;
                int nMaxCount = -1;

                for(int i = 0; i < s.Count; i++)
                {
                    int nCurCount = CountElements(u, s[i]);
                    if (nCurCount > nMaxCount) 
                    { 
                        ret = i; 
                        nMaxCount = nCurCount; 
                    } 
                    
                }

                return ret;
            };

            while(lstSets.Count > 0 && setUniverse.Count > 0)
            {
                int max = MaxElementsIndex(setUniverse, lstSets);

                ret.Add(lstSets[max]);
                setUniverse.ExceptWith(lstSets[max]);
                lstSets.RemoveAt(max);

            }

            return ret;
        }
    }
}
