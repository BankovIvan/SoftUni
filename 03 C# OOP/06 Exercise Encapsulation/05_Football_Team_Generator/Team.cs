namespace _05_Football_Team_Generator
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Team
    {
        private string name;
        private Dictionary<string, Player> players;

        public string Name {
            get { return this.name; }
            set{
                if(string.IsNullOrWhiteSpace(value)){
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;
            }
        }

        private Dictionary<string, Player> Players {
            get { return this.players; }
            set { this.players = value; }
        }

        public int Rating {
            get {
                double ret = 0.0;
                if(this.Players.Count > 0){
                    foreach(var v in this.Players){
                        ret += v.Value.SkillLevel();
                    }
                    ret /= (double)this.Players.Count;
                }
                return (int)Math.Round(ret, 0);
            }
        }

        public Team(string name)
        {
            this.Name = name;
            this.Players = new Dictionary<string, Player>();
        }

        public void AddPlayer(Player player){
            this.Players.Add(player.Name, player);
        }

        public void RemovePlayer(Player player){
            if(!this.Players.ContainsKey(player.Name)){
                throw new InvalidOperationException(
                    string.Format("Player {0} is not in {1} team.", player.Name, this.Name));
            }
            this.Players.Remove(player.Name);
        }

        public void RemovePlayer(string player){
            if(!this.Players.ContainsKey(player)){
                throw new InvalidOperationException(
                    string.Format("Player {0} is not in {1} team.", player, this.Name));
            }
            this.Players.Remove(player);
        }

        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();
            ret.AppendLine(string.Format("{0} - {1}", this.Name, this.Rating));
            return ret.ToString().Trim();
        }

    }
}