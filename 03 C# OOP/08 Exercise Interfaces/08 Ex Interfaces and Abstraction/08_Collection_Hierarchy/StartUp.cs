namespace Collection
{
    using Collection.Core;
    using Collection.Core.Interfaces;
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
