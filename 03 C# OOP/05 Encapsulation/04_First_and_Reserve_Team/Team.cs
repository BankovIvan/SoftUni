namespace PersonsInfo
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        /*public string Name {
            get {return this.name;}
            set {this.name = value;}
        }*/

        public IReadOnlyCollection<Person> FirstTeam { get { return this.firstTeam.AsReadOnly(); } }
        public IReadOnlyCollection<Person> ReserveTeam { get { return this.reserveTeam.AsReadOnly(); } }

        public Team(string name){
            this.name = name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }

        public void AddPlayer(Person player){
            if(player.Age < 40){
                this.firstTeam.Add(player);
            }
            else{
                this.reserveTeam.Add(player);
            }
        }

        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();

            ret.AppendLine(String.Format("First team has {0} players.", this.firstTeam.Count));
            ret.AppendLine(String.Format("Reserve team has {0} players.", this.reserveTeam.Count));

            return ret.ToString().Trim();
        }

    }
}