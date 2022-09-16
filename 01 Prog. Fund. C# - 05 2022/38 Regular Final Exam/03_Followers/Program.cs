namespace _03_Followers
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    //using System.Linq;
	//using System.Text.RegularExpressions;

    class Follower{
        public string Name {get; set;}
        public int Likes {get; set;}
        public int Comments {get; set;}

        public Follower(string Name){
            this.Name = Name;
            this.Likes = 0;
            this.Comments = 0;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", this.Name, this.Likes + this.Comments);
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            string[] arrCommand;
            Dictionary<string, Follower> dicFollowers = new Dictionary<string, Follower>();

            while(true){
                arrCommand = Console.ReadLine().Split(": ");
                if(arrCommand[0] == "Log out"){
                    break;
                }
                else if(arrCommand[0] == "New follower"){
                    if(! dicFollowers.ContainsKey(arrCommand[1])){
                        dicFollowers.Add(arrCommand[1], new Follower(arrCommand[1]));
                    }
                }
                else if(arrCommand[0] == "Like"){
                    if(! dicFollowers.ContainsKey(arrCommand[1])){
                        dicFollowers.Add(arrCommand[1], new Follower(arrCommand[1]));
                    }
                    dicFollowers[arrCommand[1]].Likes += int.Parse(arrCommand[2]);
                }
                else if(arrCommand[0] == "Comment"){
                    if(! dicFollowers.ContainsKey(arrCommand[1])){
                        dicFollowers.Add(arrCommand[1], new Follower(arrCommand[1]));
                    }
                    dicFollowers[arrCommand[1]].Comments++;
                }
                else if(arrCommand[0] == "Blocked"){
                    if(! dicFollowers.ContainsKey(arrCommand[1])){
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("{0} doesn't exist.", arrCommand[1]);           
                        Console.ResetColor();
                    }
                    else{
                        dicFollowers.Remove(arrCommand[1]);
                    }
                }

            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0} followers", dicFollowers.Count);
            foreach(var v in dicFollowers){
                Console.WriteLine(v.Value);
            }
            Console.ResetColor();

        }
    }
}