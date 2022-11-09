namespace Military
{
    using Military.Core;
    using Military.Core.Interfaces;
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
