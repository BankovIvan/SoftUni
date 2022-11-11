namespace Raiding
{
    using System;
    using Raiding.Core.Interfaces;
    using Raiding.Core;
    using Raiding.Factories.Interfaces;
    using Raiding.Factories;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IFactory factory = new Factory();
            IEngine engine = new Engine(factory);

            engine.Run();
        }
    }
}
