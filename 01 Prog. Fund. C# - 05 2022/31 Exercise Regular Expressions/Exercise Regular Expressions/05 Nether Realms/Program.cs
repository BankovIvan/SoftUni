using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace _05_Nether_Realms
{
    class Daemon
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public double Damage { get; set; }

        public Daemon(string Name)
        {
            this.Name = Name;
            this.Health = 0;
            this.Damage = 0.0;
        }

        public override string ToString()
        {
            return String.Format("{0} - {1} health, {2:F2} damage", this.Name, this.Health, this.Damage);
        }

        public bool SetHealth(Match matchDaemonHealth)
        {
            bool ret = matchDaemonHealth.Success;
            if (ret == true)
            {
                this.Health += (int)matchDaemonHealth.Value[0];
                /*
                foreach (var v in matchDaemonHealth.Captures)
                {
                    this.Health += (int)v.;
                }
                */
            }

            return ret;
        }

        public bool SetDamage(Match matchDaemonDamage)
        {
            bool ret = matchDaemonDamage.Success;
            if (ret == true)
            {
                this.Damage += double.Parse(matchDaemonDamage.Value);
            }

            return ret;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string sPatternHealth = @"[^0-9\+\-\*/\.]";
            string sPatternDamage = @"\+?\-?\d+\.?\d*";
            string sPatternMultiply = @"[*/]";
            //Regex regFullName = new Regex(sPattern);
            //Match matchOrder;
            MatchCollection matchDaemonHealth, matchDaemonDamage, matchDaemonMultiply;

            string[] sInput = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, Daemon> dicDaemons = new Dictionary<string, Daemon>();
            foreach(var v in sInput)
            {
                string s = v.Trim();
                dicDaemons.Add(s, new Daemon(s));

                matchDaemonHealth = Regex.Matches(s, sPatternHealth);
                foreach(Match m in matchDaemonHealth)
                {
                    dicDaemons[s].SetHealth(m);
                }

                matchDaemonDamage = Regex.Matches(s, sPatternDamage);
                foreach (Match m in matchDaemonDamage)
                {
                    dicDaemons[s].SetDamage(m);
                }

                matchDaemonMultiply = Regex.Matches(s, sPatternMultiply);
                foreach (Match m in matchDaemonMultiply)
                {
                    if(m.Value == "*")
                    {
                        dicDaemons[s].Damage *= 2.0;
                    }
                    else if((m.Value == "/"))
                    {
                        dicDaemons[s].Damage /= 2.0;
                    }
                }

            }
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach(var v in dicDaemons.OrderBy(x => x.Key))
            {
                Console.WriteLine(v.Value);
            }
            Console.ResetColor();
        }
    }
}
