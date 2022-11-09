namespace _Explicit
{
    using _Explicit.Core;
    using _Explicit.Core.Interfaces;
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
