namespace Birthday
{
    using Birthday.Core;
    using Birthday.Core.Interfaces;
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
