using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace _05_Teamwork_Projects
{
    class Program
    {
        class Team{
            public string Name {get; set;}
            public string Creator {get; set;}
            public List<string> Members {get; set;}

            public Team(){
                Members = new List<string>();
            }

            public Team(string Name, string Creator){
                Members = new List<string>();
                this.Name = Name;
                this.Creator = Creator;
            }

            public override string ToString()
            {
                StringBuilder ret = new StringBuilder(this.Name + '\n');
                ret.AppendLine("- " + this.Creator);
                if(this.Members.Count > 0){
                    this.Members.Sort();
                    this.Members.ForEach(x => ret.AppendLine("-- " + x));
                }
                return ret.ToString();
            }

        }

        static void Main(string[] args)
        {
            List<Team> lstTeams = new List<Team>();
            int i, nRepeat;
            string[] arrInput;
            StringBuilder sTeamsToDisband = new StringBuilder("Teams to disband:" + '\n');

            nRepeat = int.Parse(Console.ReadLine());

            for(i = 0; i < nRepeat; i++){
                arrInput = Console.ReadLine().Split('-');
                AddTeam(lstTeams, arrInput[1], arrInput[0]);
            }

            while(true){
                arrInput = Console.ReadLine().Split("->");

                if(arrInput[0] == "end of assignment"){
                    break;
                }

                AddMember(lstTeams, arrInput[1], arrInput[0]);

            }

            //Sort by Count then by Name
            lstTeams.Sort((x, y) => {
                int ret = y.Members.Count.CompareTo(x.Members.Count);
                if(ret == 0){
                    ret = x.Name.CompareTo(y.Name);
                }
                return ret;
            });

            //Remove empty teams and print
            lstTeams.RemoveAll(x => {
                bool ret = x.Members.Count == 0;
                if(ret == true){
                    sTeamsToDisband.AppendLine(x.Name);
                }
                return ret;
                });

            //print
            lstTeams.ForEach(x => Console.Write(x));
            Console.WriteLine(sTeamsToDisband);    

        }

        static void AddTeam(List<Team> llstTeams, string sName, string sCreator){
                
            if(llstTeams.Exists(x => x.Name == sName)){
                Console.WriteLine("Team {0} was already created!", sName);
                return;
            }

            if(llstTeams.Exists(x => x.Creator == sCreator)){
                Console.WriteLine("{0} cannot create another team!", sCreator);
                return;
            }

            llstTeams.Add(new Team(sName, sCreator));
            Console.WriteLine("Team {0} has been created by {1}!", sName, sCreator);
            return;
        }

        static void AddMember(List<Team> llstTeams, string sTeam, string sMember){
            int index = 0;

            index = llstTeams.FindIndex(x => x.Creator == sMember);
            if(index >= 0){
                Console.WriteLine("Member {0} cannot join team {1}!", sMember, sTeam);
                return;
            }

            index = llstTeams.FindIndex(x => x.Members.Contains(sMember));
            if(index >= 0){
                Console.WriteLine("Member {0} cannot join team {1}!", sMember, sTeam);
                return;
            }

            index = llstTeams.FindIndex(x => x.Name == sTeam);
            if(index < 0){
                Console.WriteLine("Team {0} does not exist!", sTeam);
                return;
            }

            llstTeams[index].Members.Add(sMember);
            return;
        }

    }
}