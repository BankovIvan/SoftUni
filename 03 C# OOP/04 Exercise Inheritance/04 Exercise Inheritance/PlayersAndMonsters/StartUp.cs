namespace PlayersAndMonsters
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Hero hero = new Hero("Hero", 1);
            Console.WriteLine(hero.ToString());

            Elf elf = new Elf("Elf", 2);
            Console.WriteLine(elf.ToString());

            MuseElf museElf = new MuseElf("MuseElf", 3);
            Console.WriteLine(museElf.ToString());

            Wizard wizard = new Wizard("Wizard", 2);
            Console.WriteLine(wizard.ToString());

            DarkWizard darkWizard = new DarkWizard("DarkWizard", 3);
            Console.WriteLine(darkWizard.ToString());

            SoulMaster soulMaster = new SoulMaster("SoulMaster", 4);
            Console.WriteLine(soulMaster.ToString());

            Knight knight = new Knight("Knight", 2);
            Console.WriteLine(knight.ToString());

            DarkKnight darkKnight = new DarkKnight("DarkKnight", 3);
            Console.WriteLine(darkKnight.ToString());

            BladeKnight bladeKnight = new BladeKnight("BladeKnight", 4);
            Console.WriteLine(bladeKnight.ToString());

        }
    }
}