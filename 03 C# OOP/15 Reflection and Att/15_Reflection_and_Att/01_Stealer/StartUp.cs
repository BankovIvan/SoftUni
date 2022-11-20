namespace Stealer
{
    using Stealer.Core;
    using Stealer.Core.Interfaces;
    using Stealer.IO;
    using Stealer.IO.Interfaces;
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            //IEngine engine = new Engine_01(reader, writer);
            //IEngine engine = new Engine_02(reader, writer);
            //IEngine engine = new Engine_03(reader, writer);
            IEngine engine = new Engine_04(reader, writer);

            engine.Run();
        }
    }
}
