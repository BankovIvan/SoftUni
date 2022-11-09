namespace _04_Border_Control
{
    using _04_Border_Control.Core;
    using _04_Border_Control.Core.Interfaces;

    public class StartUp
    {
        static void Main(string[] args)
        {

            IEngine engine = new Engine();

            engine.Run();
        }
    }
}
