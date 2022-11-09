namespace Food
{
    using Food.Core;
    using Food.Core.Interfaces;
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();

            engine.Run();
        }
    }
}
