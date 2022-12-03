namespace NavalVessels
{
    using Core;
    using Core.Contracts;
    using NavalVessels.Models;
    using NavalVessels.Models.Contracts;
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            /*
            IVessel battleship = new Battleship("BUBU", 500.0, 20.0  );
            IVessel submarine = new Submarine("IVAN", 200.0, 10.0);

            Console.WriteLine(battleship.ToString());
            Console.WriteLine(submarine.ToString());

            ((Battleship)battleship).ToggleSonarMode();
            ((Submarine)submarine).ToggleSubmergeMode();

            Console.WriteLine(battleship.ToString());
            Console.WriteLine(submarine.ToString());
            */

            IEngine engine = new Engine();
            engine.Run();
        }
    }
}