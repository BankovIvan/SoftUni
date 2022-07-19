namespace _M04_Snowwhite
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Linq;

    class Dwarf
    {
        public string Name { get; set; }
        public string HatColor { get; set; }
        public int Physics { get; set; }

        public Dwarf(string Name, string HatColor, int Physics)
        {
            this.Name = Name;
            this.HatColor = HatColor;
            this.Physics = Physics;
        }

        public override string ToString()
        {
            return String.Format("({0}) {1} <-> {2}", this.HatColor, this.Name, this.Physics);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // dwarfHatColor {dwarfName, dwarfPhysics}
            Dictionary<string, Dictionary<string, Dwarf>> dicHatColours =
                    new Dictionary<string, Dictionary<string, Dwarf>>();
            List<Dwarf> lstDwarfs = new List<Dwarf>();

            string[] arrInput;
            string sHatColor, sName;
            int nPhysics;

            while (true)
            {
                arrInput = Console.ReadLine().Split(" <:> ", StringSplitOptions.RemoveEmptyEntries);
                if (arrInput[0] == "Once upon a time")
                {
                    break;
                }

                sHatColor = arrInput[1];
                sName = arrInput[0];
                nPhysics = int.Parse(arrInput[2]);

                if (!dicHatColours.ContainsKey(sHatColor))
                {
                    dicHatColours.Add(sHatColor, new Dictionary<string, Dwarf>());
                    lstDwarfs.Add(new Dwarf(sName, sHatColor, nPhysics));
                    dicHatColours[sHatColor].Add(sName, lstDwarfs[lstDwarfs.Count - 1]);
                }
                else
                {
                    if (!dicHatColours[sHatColor].ContainsKey(sName))
                    {

                        lstDwarfs.Add(new Dwarf(sName, sHatColor, nPhysics));
                        dicHatColours[sHatColor].Add(sName, lstDwarfs[lstDwarfs.Count - 1]);
                    }
                    else
                    {
                        if (dicHatColours[sHatColor][sName].Physics < nPhysics)
                        {
                            dicHatColours[sHatColor][sName].Physics = nPhysics;
                        }
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            /*
            foreach(var v in lstDwarfs
                                .OrderByDescending(x => x.Physics)
                                .GroupBy(x => x.Name)
                                .OrderByDescending(x => x.Count())
                                .SelectMany(x => x)
                                .ToList()
                                ){
                Console.WriteLine(v);
            }
            */
            foreach (var v in lstDwarfs
                                .OrderByDescending(x => x.Physics)
                                .ThenByDescending(y => {
                                    //Console.WriteLine(y.Name + "->" + dicHatColours[y.HatColor].Count);
                                    return dicHatColours[y.HatColor].Count;
                                })
                                )
            {
                Console.WriteLine(v);
            }
            Console.ResetColor();

        }
    }
}