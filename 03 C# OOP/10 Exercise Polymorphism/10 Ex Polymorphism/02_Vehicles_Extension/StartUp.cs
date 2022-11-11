namespace Vehicles
{
    using System;
    using Vehicles.Core.Interfaces;
    using Vehicles.Core;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();

            engine.Run();
        }
    }
}
