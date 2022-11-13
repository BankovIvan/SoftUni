namespace _05_Football_Team_Generator
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        static void Main(string[] args)
        {
            //Team t = new Team("KUR");
            //Console.ForegroundColor = ConsoleColor.Blue;
            //Console.WriteLine(t.ToString());
            //Console.ResetColor();

            Dictionary<string, Team> dicTeams = new Dictionary<string, Team>();
            string[] arrInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            while(arrInput[0] != "END"){

                try{
                    if(arrInput[0] == "Team"){
                        AddTeam(ref dicTeams, arrInput);
                    }
                    else if(arrInput[0] == "Add"){
                        AddPlayer(ref dicTeams, arrInput);
                    }
                    else if(arrInput[0] == "Remove"){
                        RemovePlayer(ref dicTeams, arrInput);
                    }
                    else if(arrInput[0] == "Rating"){
                        PrintRating(ref dicTeams, arrInput);
                    }
                }
                catch(Exception e){
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                }

                arrInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            }

            static void AddTeam(ref Dictionary<string, Team> dicTeams, string[] arrInput){
                Team team = new Team(arrInput[1]);
                dicTeams.Add(arrInput[1], team);
            }

            static void AddPlayer(ref Dictionary<string, Team> dicTeams, string[] arrInput){
                if(!dicTeams.ContainsKey(arrInput[1])){
                    throw new InvalidOperationException(
                        string.Format("Team {0} does not exist.", arrInput[1]));
                }

                string name = arrInput[2];
                int endurance = int.Parse(arrInput[3]);
                int sprint = int.Parse(arrInput[4]);
                int dribble = int.Parse(arrInput[5]);
                int passing = int.Parse(arrInput[6]);
                int shooting = int.Parse(arrInput[7]);

                Player player = new Player(name, endurance, sprint, dribble, passing, shooting);
                dicTeams[arrInput[1]].AddPlayer(player);
            }

            static void RemovePlayer(ref Dictionary<string, Team> dicTeams, string[] arrInput){
                if(!dicTeams.ContainsKey(arrInput[1])){
                    throw new InvalidOperationException(
                        string.Format("Team {0} does not exist.", arrInput[1]));
                }

                dicTeams[arrInput[1]].RemovePlayer(arrInput[2]);
            }

            static void PrintRating(ref Dictionary<string, Team> dicTeams, string[] arrInput){
                if(!dicTeams.ContainsKey(arrInput[1])){
                    throw new InvalidOperationException(
                        string.Format("Team {0} does not exist.", arrInput[1]));
                }

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(dicTeams[arrInput[1]].ToString());
                Console.ResetColor();
            }

        }
    }
}
