namespace _M02_Judge
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Linq;

    class User{
        public string UserName {get; set;}
        public int TotalPoints {get; set;}

        public User(string UserName, int TotalPoints = 0){ 
            this.UserName = UserName;
            this.TotalPoints = TotalPoints;
        }

        public override string ToString()
        {
            return string.Format("{0} -> {1}", this.UserName, this.TotalPoints);
        }

    }

    class UserStats{
        public Dictionary<string, User> Users {get; set;}

        public UserStats(){
            Users = new Dictionary<string, User>();
        }

        public override string ToString()
        {
            string ret = "Individual standings:";
            int i = 1;

            foreach(var v in this.Users.OrderByDescending(x => x.Value.TotalPoints).ThenBy(x => x.Key)){
                
                ret = ret + string.Format("\n{0}. {1}", i++, v.Value);        

            }

            return ret;
        }

        public void UpdateUser(string UserName, int Points){
            if(! this.Users.ContainsKey(UserName)){
                this.Users.Add(UserName, new User(UserName, Points));
            }
            else{
                this.Users[UserName].TotalPoints += Points;
            }
        }
    }

    class Contest{
        public string ContestName {get; set;}
        public Dictionary<string, int> ContestPoints; //<User, Points>

        public Contest(string UserName, string ContestName, int Points){
            this.ContestName = ContestName;
            this.ContestPoints = new Dictionary<string, int>();
            this.ContestPoints.Add(UserName, Points); 
        }

        public override string ToString()
        {
            string ret = string.Format("{0}: {1} participants", this.ContestName, this.ContestPoints.Count);
            int i = 1;

            foreach(var v in this.ContestPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key)){
                ret = ret + string.Format("\n{0}. {1} <::> {2}", i++, v.Key, v.Value);
            }
            
            return ret;
        }

        public void AddContestant(string UserName, int Points){
            if(! this.ContestPoints.ContainsKey(UserName)){
                this.ContestPoints.Add(UserName, Points);
            }
            else{
                if(Points > this.ContestPoints[UserName]){
                    this.ContestPoints[UserName] = Points;
                }
            }
        }
    } 


    class Program
    {
        static void Main(string[] args)
        {
            List<Contest> lstContests = new List<Contest>();
            UserStats objUserStats = new UserStats();
            string[] arrInput;
            int index = 0;

            while(true){
                arrInput = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                if(arrInput[0] == "no more time"){
                    break;
                }

                index = lstContests.FindIndex(x => x.ContestName == arrInput[1]);
                if(index < 0){
                    lstContests.Add(new Contest(arrInput[0], arrInput[1], int.Parse(arrInput[2])));
                }else{
                    lstContests[index].AddContestant(arrInput[0], int.Parse(arrInput[2]));
                }

                //objUserStats.UpdateUser(arrInput[0], int.Parse(arrInput[2]));
            }

            foreach(var v in lstContests){
                foreach(var w in v.ContestPoints){
                    objUserStats.UpdateUser(w.Key, w.Value);
                }
            } 

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach(var v in lstContests){
                Console.WriteLine(v);
            }           
            Console.WriteLine(objUserStats);
            Console.ResetColor();

        }
    }
}