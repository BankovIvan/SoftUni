namespace _M05_Dragon_Army
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Linq;

    class Dragon{
        public string Type {get; set;}
        public string Name {get; set;}
        public int Damage {get; set;}
        public int Health {get; set;}
        public int Armor {get; set;}

        public Dragon(string Type, string Name, string Damage, string Health, string Armor){
            this.Type = Type;
            this.Name = Name;
            
            if(Damage != "null"){
                this.Damage = int.Parse(Damage);
            }else{
                this.Damage = 45;
            }

            if(Health != "null"){
                this.Health = int.Parse(Health);
            }else{
                this.Health = 250;
            }

            if(Armor != "null"){
                this.Armor = int.Parse(Armor);
            }else{
                this.Armor = 10;
            }
        }

        public override string ToString()
        {
            return String.Format("-{0} -> damage: {1}, health: {2}, armor: {3}",
                                    this.Name, this.Damage, this.Health, this.Armor);
        }

        public void UpdateDragon(string Damage, string Health, string Armor){
            if(Damage != "null"){
                this.Damage = int.Parse(Damage);
            }else{
                this.Damage = 45;
            }

            if(Health != "null"){
                this.Health = int.Parse(Health);
            }else{
                this.Health = 250;
            }

            if(Armor != "null"){
                this.Armor = int.Parse(Armor);
            }else{
                this.Armor = 10;
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            // "<type <name, {damage, health, armor}>>"
            Dictionary<string, SortedDictionary<string, Dragon>> lstDragons = 
                                    new Dictionary<string, SortedDictionary<string, Dragon>>();
            int i, nRepeat;
            string[] arrInput;

            nRepeat = int.Parse(Console.ReadLine());
            for(i = 0; i < nRepeat; i++){
                arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if(! lstDragons.ContainsKey(arrInput[0])){
                    lstDragons.Add(
                                    arrInput[0], 
                                    new SortedDictionary<string, Dragon>()
                                    );
                    lstDragons[arrInput[0]].Add(
                                    arrInput[1],
                                    new Dragon(arrInput[0], arrInput[1], arrInput[2], arrInput[3], arrInput[4])
                                    );
                }
                else if(! lstDragons[arrInput[0]].ContainsKey(arrInput[1])){
                    lstDragons[arrInput[0]].Add(
                                    arrInput[1],
                                    new Dragon(arrInput[0], arrInput[1], arrInput[2], arrInput[3], arrInput[4])
                                    );
                }else{
                    lstDragons[arrInput[0]][arrInput[1]].UpdateDragon(arrInput[2], arrInput[3], arrInput[4]);
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach(var vType in lstDragons){
                double dTotalDamage = vType.Value.Values.Average(x => x.Damage);
                double dTotalHealth = vType.Value.Values.Average(x => x.Health);
                double dTotalArmor = vType.Value.Values.Average(x => x.Armor);

                Console.WriteLine("{0}::({1:F2}/{2:F2}/{3:F2})", 
                                    vType.Key, dTotalDamage, dTotalHealth, dTotalArmor);

                foreach(var vName in vType.Value){
                    Console.WriteLine(vName.Value);
                }

            }      
            Console.ResetColor();

        }
    }
}