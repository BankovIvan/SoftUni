namespace _M01_Ranking
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    //using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            //{contest}:{password for contest}
            Dictionary<string, string> dicContests = new Dictionary<string, string>(); 
            
            //{username}=>{{contest1} -> {points}}
            SortedDictionary<string, Dictionary<string, int>> dicInterns = 
                    new SortedDictionary<string, Dictionary<string, int>>();

            string[] arrInput;

            while(true){
                arrInput = Console.ReadLine().Split(':', StringSplitOptions.RemoveEmptyEntries);
                if(arrInput[0] == "end of contests"){
                    break;
                }

                AddContestData(dicContests, arrInput);
            }

            while(true){
                arrInput = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);
                if(arrInput[0] == "end of submissions"){
                    break;
                }

                AddInternData(dicContests, dicInterns, arrInput);
            }

            PrintInternData(dicInterns);

        }

        public static void AddContestData(
                Dictionary<string, string> dicContests, 
                string[] arrInput
                ){
        
            //arrInput[] = {contest}:{password for contest}
            dicContests.Add(arrInput[0], arrInput[1]);

            return;
        }

        public static void AddInternData(
                Dictionary<string, string> dicContests,
                SortedDictionary<string, Dictionary<string, int>> dicInterns,
                string[] arrInput
                ){
            
            int nPoints = int.Parse(arrInput[3]);

            //arrInput[] = {contest}=>{password}=>{username}=>{points}
            if(! dicContests.ContainsKey(arrInput[0])){
                //Contest not found;
                return;
            }
            
            if(dicContests[arrInput[0]] != arrInput[1]){
                //Wrong password;
                return;
            }
            
            if(! dicInterns.ContainsKey(arrInput[2])){
                //New user
                dicInterns.Add(arrInput[2], new Dictionary<string, int>());
                dicInterns[arrInput[2]].Add(arrInput[0], nPoints);
                return;
            }

            if(dicInterns[arrInput[2]].ContainsKey(arrInput[0])){
                //Existing User, existing Contest in the list
                if(nPoints > dicInterns[arrInput[2]][arrInput[0]]){
                    dicInterns[arrInput[2]][arrInput[0]] = nPoints;
                }
                return;
            }

            //Existing User, New Contest
            dicInterns[arrInput[2]].Add(arrInput[0], nPoints);
            return;
        }

        public static void PrintInternData(
                SortedDictionary<string, Dictionary<string, int>> dicInterns
                ){
        
            string sMaxKey = "";
            int nMaxPoints = 0;

            //Max user
            foreach(var v in dicInterns){
                int nUserPoints = 0;
                foreach(var w in v.Value){
                    nUserPoints += w.Value;
                }

                if(nUserPoints > nMaxPoints){
                    nMaxPoints = nUserPoints;
                    sMaxKey = v.Key;
                }

            }

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Best candidate is {0} with total {1} points.", sMaxKey, nMaxPoints);   
            Console.WriteLine("Ranking: ");

            foreach(var v in dicInterns){
                Console.WriteLine(v.Key);
                
                //List<KeyValuePair<string, int>> ContestList = v.Value.ToList();
                List<KeyValuePair<string, int>> ContestList = new List<KeyValuePair<string, int>>(v.Value);

                ContestList.Sort((x, y) => y.Value.CompareTo(x.Value));
                ContestList.ForEach(x => {
                    Console.WriteLine("#  {0} -> {1}", x.Key, x.Value);
                });

            }

            Console.ResetColor();



            return;
        }


    }
}