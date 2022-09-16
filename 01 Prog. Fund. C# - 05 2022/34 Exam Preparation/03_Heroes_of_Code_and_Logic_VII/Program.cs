namespace _03_Heroes_of_Code_and_Logic_VII
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    //using System.Linq;
	//using System.Text.RegularExpressions;

    class Hero{
        public string Name {get; set;}
        public int HP {get; set;}
        public int MP {get; set;}

        public Hero(string Name, int HP, int MP){
            this.Name = Name;
            this.HP = HP;
            this.MP = MP;
            if(this.HP > 100){
                this.HP = 100;
            }
            if(this.MP > 200){
                this.MP = 200;
            }
            
        }

        public override string ToString()
        {
            return string.Format("{0}\n  HP: {1}\n  MP: {2}", this.Name, this.HP, this.MP);
        }

        public void CastSpell(int MP, string sSpellName){
            if(this.MP >= MP){
                
                this.MP -= MP;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("{0} has successfully cast {1} and now has {2} MP!", 
                                        this.Name, sSpellName, this.MP);           
                Console.ResetColor();
            }
            else{
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("{0} does not have enough MP to cast {1}!", 
                                        this.Name, sSpellName);           
                Console.ResetColor();
            }
        }

        public bool TakeDamage(int HP, string sAttacker){
            bool ret = false;

            if(this.HP > HP){
                this.HP -= HP;
                ret = true;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("{0} was hit for {1} HP by {2} and now has {3} HP left!", 
                                        this.Name, HP, sAttacker, this.HP);           
                Console.ResetColor();

            }
            else{
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("{0} has been killed by {1}!", 
                                        this.Name, sAttacker);           
                Console.ResetColor();
            }

            return ret;

        }

        public void Recharge(int MP){
            int recharge = MP;

            this.MP += MP;
            if(this.MP > 200){
                recharge -= (this.MP - 200);
                this.MP = 200;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0} recharged for {1} MP!", this.Name, recharge);           
            Console.ResetColor();
        }

        public void Heal(int HP){
            int recharge = HP;

            this.HP += HP;
            if(this.HP > 100){
                recharge -= (this.HP - 100);
                this.HP = 100;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0} healed for {1} HP!", this.Name, recharge);           
            Console.ResetColor();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int i, nRepeat;
            string[] arrInput;
            Dictionary<string, Hero> dicHeroes = new Dictionary<string, Hero>();

            nRepeat = int.Parse(Console.ReadLine());
            for(i = 0; i < nRepeat; i++){
                arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                dicHeroes.Add(arrInput[0], new Hero(arrInput[0], int.Parse(arrInput[1]), int.Parse(arrInput[2])));

            }

            while(true){
                 arrInput = Console.ReadLine().Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                 if(arrInput[0] == "End"){
                    break;
                 }
                else if(arrInput[0] == "CastSpell"){
                    dicHeroes[arrInput[1]].CastSpell(int.Parse(arrInput[2]), arrInput[3]);
                }
                else if(arrInput[0] == "TakeDamage"){
                    if(! dicHeroes[arrInput[1]].TakeDamage(int.Parse(arrInput[2]), arrInput[3])){
                        dicHeroes.Remove(arrInput[1]);
                    }
                }
                else if(arrInput[0] == "Recharge"){
                    dicHeroes[arrInput[1]].Recharge(int.Parse(arrInput[2]));
                }
                else if(arrInput[0] == "Heal"){
                    dicHeroes[arrInput[1]].Heal(int.Parse(arrInput[2]));
                }

            }

            foreach(var v in dicHeroes){
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(v.Value);           
                Console.ResetColor();
            }


        }
    }
}