namespace _M03_MOBA_Challenger
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Linq;

    class MOBAPlayer
    {
        public string Name { get; set; }
        public int TotalSkill { get; set; }
        public Dictionary<string, int> Positions { get; set; } //Position, Skill

        public MOBAPlayer(string Name, string Position, int Skill)
        {
            this.Name = Name;
            this.TotalSkill = Skill;
            this.Positions = new Dictionary<string, int>();
            this.Positions.Add(Position, Skill);

        }

        public override string ToString()
        {
            string ret = string.Format("{0}: {1} skill", this.Name, this.TotalSkill);
            foreach (var v in this.Positions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                ret = ret + string.Format("\n- {0} <::> {1}", v.Key, v.Value);
            }
            return ret;
        }

        public void UpdateSkill(string Position, int Skill)
        {
            if (this.Positions.ContainsKey(Position))
            {
                if (this.Positions[Position] < Skill)
                {
                    this.TotalSkill += Skill - this.Positions[Position];
                    this.Positions[Position] = Skill;
                }
            }
            else
            {
                this.Positions.Add(Position, Skill);
                this.TotalSkill += Skill;
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, MOBAPlayer> dicPlayers = new Dictionary<string, MOBAPlayer>();
            string[] arrInput;

            while (true)
            {
                arrInput = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                if (arrInput[0] == "Season end")
                {
                    break;
                }
                if (arrInput.Length > 1)
                {
                    if (!dicPlayers.ContainsKey(arrInput[0]))
                    {
                        dicPlayers.Add(arrInput[0],
                                        new MOBAPlayer(arrInput[0], arrInput[1], int.Parse(arrInput[2])));
                    }
                    else
                    {
                        dicPlayers[arrInput[0]].UpdateSkill(arrInput[1], int.Parse(arrInput[2]));
                    }
                }
                else
                {
                    arrInput = arrInput[0].Split(" vs ", StringSplitOptions.RemoveEmptyEntries);
                    MOBADuel(dicPlayers, arrInput[0], arrInput[1]);
                }

            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var v in dicPlayers.OrderByDescending(x => x.Value.TotalSkill).ThenBy(x => x.Key))
            {
                Console.WriteLine(v.Value);
            }
            Console.ResetColor();

        }

        static void MOBADuel(Dictionary<string, MOBAPlayer> dicPlayers,
                                string sPlayer1, string sPlayer2)
        {
            MOBAPlayer objPlayer1, objPlayer2;
            bool bCommonSkill = false;

            if (!(dicPlayers.ContainsKey(sPlayer1) && dicPlayers.ContainsKey(sPlayer2)))
            {
                return;
            }

            objPlayer1 = dicPlayers[sPlayer1];
            objPlayer2 = dicPlayers[sPlayer2];

            foreach (var v in objPlayer1.Positions)
            {
                if (objPlayer2.Positions.ContainsKey(v.Key))
                {
                    bCommonSkill = true;
                    break;
                }
            }

            if (bCommonSkill == true)
            {
                if (objPlayer1.TotalSkill > objPlayer2.TotalSkill)
                {
                    dicPlayers.Remove(objPlayer2.Name);
                }
                else if (objPlayer1.TotalSkill < objPlayer2.TotalSkill)
                {
                    dicPlayers.Remove(objPlayer1.Name);
                }
            }

            return;
        }

    }
}